using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Mail;
using SendGrid;
using Your_Money.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;

namespace Your_Money.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public UsuariosController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Email,Senha")] Usuario usuario)
        {
            var user = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Email == usuario.Email);

            if (user == null)
            {
                ViewBag.Message = "E-mail e/ou Senha inválidos, favor verifique as informações!";
                return View();
            }

            if (usuario.Senha == null)
            {
                ViewBag.Message = "E-mail e/ou Senha inválidos, favor verifique as informações!";
                return View();
            }

            bool isSenhaOk = BCrypt.Net.BCrypt.Verify(usuario.Senha, user.Senha);

            if (isSenhaOk)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.NameIdentifier, user.Nome),
                    new Claim(ClaimTypes.Email, user.Email)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.Now.ToLocalTime().AddDays(7),
                    IsPersistent = true
                };

                await HttpContext.SignInAsync(principal, props);

                return Redirect("/Usuarios/Index");
            }

            ViewBag.Message = "E-mail e/ou Senha inválidos!";
            return View(usuario);
        }

        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        // GET: Usuarios
        public async Task<IActionResult> Index(int mes, int ano)
        {
            var userEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email)?.Value;

            var lancamentoDbContext = _context.Lancamentos.Where(i => i.Contas.Usuario.Email == userEmail);
            var lancamentos = await lancamentoDbContext.ToListAsync();

            if (mes == 0)
                mes = DateTime.Now.Month;

            if (ano == 0)
                ano = DateTime.Now.Year;

            var valorReceitas = lancamentos.Where(x => x.Tipo == Transacao.Receita &&
                                                  x.Data.Year == ano &&
                                                  x.Data.Month == mes).Sum(x => x.Valor);

            var valorDespesas = lancamentos.Where(x => x.Tipo == Transacao.Despesa &&
                                                  x.Data.Year == ano &&
                                                  x.Data.Month == mes).Sum(x => x.Valor);

            ViewBag.ValorReceitas = valorReceitas;
            ViewBag.ValorDespesas = valorDespesas;
            ViewBag.Saldo = valorReceitas - valorDespesas;

            var usuarioDbContext = _context.Usuarios.Where(i => i.Email == userEmail);
            return View(await usuarioDbContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha,ConfirmarSenha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if (usuario.ConfirmacaoSenha())
                {
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    var account = new Conta { SaldoTotal = 0 };
                    usuario.conta = account;
                    _context.Add(usuario);
                    await _context.SaveChangesAsync();
                    return Redirect("/Usuarios/Login");
                }
                else
                {
                    ModelState.AddModelError("ConfirmacaoSenha", "As senhas não coincidem.");
                }

            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Senha,ConfirmarSenha")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (usuario.ConfirmacaoSenha())
                {
                    try
                    {
                        usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                        _context.Update(usuario);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UsuarioExists(usuario.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        public string GerarTokenRecuperacaoSenha()
        {
            // Gerar um token único usando um GUID (Identificador Global Único)
            var token = Guid.NewGuid().ToString();

            // Codificar o token como Base64 para torná-lo seguro para inclusão em URLs
            var tokenBytes = Encoding.UTF8.GetBytes(token);
            var encodedToken = WebEncoders.Base64UrlEncode(tokenBytes);

            _context.SaveChanges();

            return encodedToken;
        }

        [HttpPost]
        public async Task<IActionResult> RecuperarSenha(string email)
        {
            // Localiza o usuário pelo email
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                // Usuário não encontrado
                return View("UsuarioNaoEncontrado");
            }


            // Gerar um token de recuperação de senha
            usuario.GerarTokenRecuperacaoSenha();

            // Salva o usuário com o token gerado no banco de dados
            _context.Update(usuario); // Adiciona o usuário modificado ao contexto
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

            // Envia o e-mail de recuperação de senha
            var apiKey = _configuration["SendGridSettings:ApiKey"];
            var senderEmail = _configuration["SendGridSettings:SenderEmail"];

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(senderEmail);
            var to = new EmailAddress(usuario.Email);
            var subject = "Recuperação de Senha";
            var plainTextContent = $"Clique no link a seguir para recuperar sua senha: {Url.Action("ResetarSenha", "Usuarios", new { token = usuario.TokenRecuperacaoSenha }, Request.Scheme)}";
            var htmlContent = $"<p>Clique no link a seguir para recuperar sua senha:</p><p><a href=\"{Url.Action("ResetarSenha", "Usuarios", new { token = usuario.TokenRecuperacaoSenha }, Request.Scheme)}\">Recuperar Senha</a></p>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);

            return ExibirEmailEnviado();
        }

        public IActionResult ResetarSenha(string token)
        {
            // Verificar se o token é válido e exibir a view para redefinir a senha
            var usuario = _context.Usuarios.FirstOrDefault(u => u.TokenRecuperacaoSenha == token);

            if (usuario != null)
            {
                // Gerar e atribuir o novo token
                string novoToken = GerarTokenRecuperacaoSenha();
                usuario.TokenRecuperacaoSenha = novoToken;

                // Salvar as alterações no banco de dados
                _context.SaveChanges();
            }

            // Token válido, exibir a view para redefinir a senha
            return ExibirResetarSenha();
        }

        [HttpPost]
        public async Task<IActionResult> ResetarSenha(string token, string novaSenha)
        {
            // Verificar se o token é válido e atualizar a senha do usuário
            var usuario = _context.Usuarios.FirstOrDefault(u => u.TokenRecuperacaoSenha == token);

            if (usuario != null)
            {
                // Atualizar a senha do usuário com a nova senha fornecida
                usuario.Senha = novaSenha;


                // Limpar o token de recuperação 
                usuario.TokenRecuperacaoSenha = null;

                // Salvar as alterações no banco de dados
                await _context.SaveChangesAsync();

                return ExibirSenhaRedefinida();
            }
            else
            {
                // Caso o usuário não seja encontrado, você pode lidar com isso de acordo com a sua lógica, como exibir uma mensagem de erro ou redirecionar para uma página adequada.
                // Exemplo de redirecionamento para uma página de erro
                return ExibirTokenInvalido();
            }
        }

        [HttpGet]
        public IActionResult ExibirRecuperarSenha()
        {
            return View("RecuperarSenha");
        }

        [HttpGet]
        public IActionResult ExibirResetarSenha()
        {
            return View("ResetarSenha");
        }

        [HttpGet]
        public IActionResult ExibirEmailEnviado()
        {
            return View("EmailEnviado");
        }

        [HttpGet]
        public IActionResult ExibirSenhaRedefinida()
        {
            return View("SenhaRedefinida");
        }

        [HttpGet]
        public IActionResult ExibirTokenInvalido()
        {
            return View("TokenInvalido");
        }
    }
}
