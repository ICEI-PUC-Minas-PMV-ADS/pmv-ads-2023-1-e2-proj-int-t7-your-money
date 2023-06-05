
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SendGrid.Helpers.Mail;
using SendGrid;
using Your_Money.Models;
using Newtonsoft.Json.Linq;
using System.IO;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize]
        public async Task<IActionResult> Index(int mes, int ano)
        {
            var userEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email)?.Value;

            var lancamentoDbContext = _context.Lancamentos.Where(i => i.Contas.Usuario.Email == userEmail);
            var lancamentos = await lancamentoDbContext.Include(p => p.Parcelamentos).ToListAsync();

            if (mes == 0)
                mes = DateTime.Now.Month;

            if (ano == 0)
                ano = DateTime.Now.Year;

            var valorReceitasLancamentos = lancamentos.Where(x => x.Tipo == Transacao.Receita &&
                                                  x.Status == StatusTransacao.Efetivado &&
                                                  (x.NumeroParcelas == 0 || x.NumeroParcelas == 1) &&
                                                  x.Data.Year == ano &&
                                                  x.Data.Month == mes).Sum(x => x.Valor);

            var valorReceitasParcelas = lancamentos.Where(x => x.Tipo == Transacao.Receita &&
                                                          x.NumeroParcelas > 1)
                                                   .SelectMany(l => l.Parcelamentos)
                                                   .Where(p => p.Status == true &&
                                                          p.DataVencimento.Year == ano &&
                                                          p.DataVencimento.Month == mes)
                                                   .Sum(x => x.Valor);

            var valorReceitas = valorReceitasLancamentos + valorReceitasParcelas;

            var valorDespesasLancamentos = lancamentos.Where(x => x.Tipo == Transacao.Despesa &&
                                                  x.Status == StatusTransacao.Efetivado &&
                                                  (x.NumeroParcelas == 0 || x.NumeroParcelas == 1) &&
                                                  x.Data.Year == ano &&
                                                  x.Data.Month == mes).Sum(x => x.Valor);

            var valorDespesasParcelas = lancamentos.Where(x => x.Tipo == Transacao.Despesa &&
                                                          x.NumeroParcelas > 1)
                                                   .SelectMany(l => l.Parcelamentos)
                                                   .Where(p => p.Status == true &&
                                                          p.DataVencimento.Year == ano &&
                                                          p.DataVencimento.Month == mes)
                                                   .Sum(x => x.Valor);

            var valorDespesas = valorDespesasLancamentos + valorDespesasParcelas;

            var valorReceitasTotal = lancamentos.Where(x => x.Tipo == Transacao.Receita &&
                                                       x.Status == StatusTransacao.Efetivado          
                                                              ).Sum(x => x.Valor);
            
            var valorDespesasTotal = lancamentos.Where(x => x.Tipo == Transacao.Despesa &&
                                                                   x.Status == StatusTransacao.Efetivado
                                                              ).Sum(x => x.Valor);

            ViewBag.ValorReceitas = valorReceitas;
            ViewBag.ValorDespesas = valorDespesas;
            ViewBag.Saldo = valorReceitas - valorDespesas;
            ViewBag.SaldoTotal = valorReceitasTotal - valorDespesasTotal;

            var usuarioDbContext = _context.Usuarios.Where(i => i.Email == userEmail);
            var usuarios = await usuarioDbContext.ToListAsync();

            // Obter todos os lançamentos pendentes
            var lancamentosPendentes = _context.Lancamentos
                .Where(i => i.Contas.Usuario.Email == userEmail && i.Status == StatusTransacao.Pendente)
                .ToList();

            // Passar os lançamentos pendentes para a view
            ViewBag.LancamentosPendentes = lancamentosPendentes;

            return View(usuarios);
        }


        [Authorize]
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
            TempData["ToastMessage"] = "Usuário criado com sucesso!";
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
                    var existingUser = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);
                    if (existingUser != null)
                    {
                        ModelState.AddModelError("Email", "Já existe um usuário com este email.");
                        return View(usuario);
                    }

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

        [Authorize]
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
        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        public string GerarCodigoTemporario()
        {
            // Gerar um código alfanumérico aleatório
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var codigo = new string(Enumerable.Repeat(caracteres, 6)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return codigo;
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
            else { 

            // Gerar um token de recuperação de senha
            var codigoTemporario = GerarCodigoTemporario();

            // Salva o usuário com o token gerado no banco de dados
            usuario.CodigoTemporario = codigoTemporario; // Adiciona o usuário modificado ao contexto
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

                // Envia o e-mail de recuperação de senha
            var apiKey = _configuration["SendGridSettings:ApiKey"];
            var senderEmail = _configuration["SendGridSettings:SenderEmail"];

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(senderEmail);
            var to = new EmailAddress(usuario.Email);
            var subject = "Recuperação de Senha";
            var plainTextContent = $"Seu código temporário é: {codigoTemporario} <br> Clique no link a seguir para recuperar sua senha: {Url.Action("ResetarSenha", "Usuarios", new { codigoTemporario = usuario.CodigoTemporario }, Request.Scheme)}";
            var htmlContent = $"<p>Seu código temporário é: {codigoTemporario} <br> Clique no link a seguir para recuperar sua senha:</p><p><a href=\"{Url.Action("ResetarSenha", "Usuarios", new { codigoTemporario = usuario.CodigoTemporario }, Request.Scheme)}\">Recuperar Senha</a></p>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            await client.SendEmailAsync(msg);

            return ExibirEmailEnviado();
            }
        }

        public IActionResult ResetarSenha(string codigo)
        {
            // Verifica se o token é válido e exibir a view para redefinir a senha
            var usuario = _context.Usuarios.FirstOrDefault(u => u.CodigoTemporario == codigo);

            if (usuario != null)
            {
                // Gera e atribui o novo código
                string novoCodigo = GerarCodigoTemporario();
                usuario.CodigoTemporario = novoCodigo;

                // Salva as alterações no banco de dados
                _context.SaveChanges();

                return View("ResetarSenha", usuario);
            }

            // Caso o código seja válido, exibir a view para redefinir a senha
            return RedirectToAction("TokenInvalido");
        }

        [HttpPost]
        public IActionResult ResetarSenha(string codigoTemporario, string novaSenha)
        {
            // Verificar se o código temporário é válido e atualizar a senha do usuário
            var usuario = _context.Usuarios.FirstOrDefault(u => u.CodigoTemporario == codigoTemporario);

            if (usuario != null)
            {
                // Atualizar a senha do usuário com a nova senha fornecida
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(novaSenha);
                

                // Limpar o código temporário
                usuario.CodigoTemporario = null;

                // Salvar as alterações no banco de dados
               _context.SaveChanges();

                return ExibirSenhaRedefinida();
            }

            // Se o código temporário for inválido, redirecionar para uma página de erro
            return RedirectToAction("TokenInvalido");
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
