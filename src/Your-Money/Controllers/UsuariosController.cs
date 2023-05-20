using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Your_Money.Models;

namespace Your_Money.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
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
            
            var valorReceitasTotal = lancamentos.Where(x => x.Tipo == Transacao.Receita).Sum(x => x.Valor);
            
            var valorDespesasTotal = lancamentos.Where(x => x.Tipo == Transacao.Despesa).Sum(x => x.Valor);

            ViewBag.ValorReceitas = valorReceitas;
            ViewBag.ValorDespesas = valorDespesas;
            ViewBag.Saldo = valorReceitas - valorDespesas;
            ViewBag.SaldoTotal = valorReceitasTotal - valorDespesasTotal;

            //Gráficos
            int anoAtual = DateTime.Now.Year;

            ViewBag.AnoAtual = anoAtual;

            int mesAtual = DateTime.Now.Month;


            ViewBag.MesAtual = mesAtual;

            Dictionary<int, (int receitasMes, int despesasMes)> lancamentosMes = new Dictionary<int, (int, int)>();

            for (int mesRelatorio = 1; mesRelatorio <= 12; mesRelatorio++)
            {
                var (receitasMes, despesasMes) = GetLancamentosMes(mesRelatorio, anoAtual);
                lancamentosMes[mesRelatorio] = (receitasMes, despesasMes);
            }

            ViewBag.LancamentosMes = lancamentosMes;

            var usuarioDbContext = _context.Usuarios.Where(i => i.Email == userEmail);
            return View(await usuarioDbContext.ToListAsync());
        }


        // Gráficos
        public (int receitasMes, int despesasMes) GetLancamentosMes(int mes, int ano)
        {
            int contagemDeLancamentosReceita = 0;
            int contagemDeLancamentosDespesas = 0;

            foreach (var lancamento in _context.Lancamentos.Where(l => l.Data.Month == mes &&
                                                                      l.Data.Year == ano &&
                                                                      l.Tipo == Transacao.Receita))
            {
                contagemDeLancamentosReceita += 1;
            }

            foreach (var lancamento in _context.Lancamentos.Where(l => l.Data.Month == mes &&
                                                                      l.Data.Year == ano &&
                                                                      l.Tipo == Transacao.Despesa))
            {
                contagemDeLancamentosDespesas += 1;
            }

            return (contagemDeLancamentosReceita, contagemDeLancamentosDespesas);
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
        public async Task<IActionResult> Create([Bind("Id,Nome,Email,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                var account = new Conta { SaldoTotal = 0 };
                usuario.conta = account;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return Redirect("/Usuarios/Login");
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Senha")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
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
    }
}
