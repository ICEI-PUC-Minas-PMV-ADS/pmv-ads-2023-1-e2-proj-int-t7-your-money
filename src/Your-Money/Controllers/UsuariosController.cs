using System;
using System.Collections.Generic;
using System.Globalization;
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
using Microsoft.AspNetCore.Mvc.ViewFeatures;



namespace Your_Money.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly CultureInfo _cultura;

        public UsuariosController(ApplicationDbContext context, CultureInfo cultura)
        {
            _context = context;
            _cultura = cultura;
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

                ClaimsPrincipal principal = new(userIdentity);

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

        public async Task<IActionResult> Logout()
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

            decimal porcentagemDespesas = 0;

            if (valorReceitas != 0)
            {
                porcentagemDespesas = valorDespesas / valorReceitas * 100;
            }
            else if (valorDespesas != 0)
            {
                porcentagemDespesas = 100; 
            }

            string nomeMes = _cultura.DateTimeFormat.GetMonthName(mes);
            string alertClass = GetAlertClass(porcentagemDespesas);

            if (porcentagemDespesas > 95)
            {
                ViewBag.AlertClass = "alert-danger";
                ViewBag.AlertMessage = "As despesas tomaram " + porcentagemDespesas.ToString("F2") + "% das receitas no mês de " + nomeMes + "!";
            }
            else if (porcentagemDespesas > 85 && porcentagemDespesas <= 95)
            {
                ViewBag.AlertClass = "alert-orange";
                ViewBag.AlertMessage = "As despesas tomaram " + porcentagemDespesas.ToString("F2") + "% das receitas no mês de " + nomeMes + "!";
            }
            else if (porcentagemDespesas >= 75 && porcentagemDespesas <= 85)
            {
                ViewBag.AlertClass = "alert-warning";
                ViewBag.AlertMessage = "As despesas tomaram " + porcentagemDespesas.ToString("F2") + "% das receitas no mês de " + nomeMes + "!";
            }


            ViewBag.ValorReceitas = valorReceitas;
            ViewBag.ValorDespesas = valorDespesas;
            ViewBag.Saldo = valorReceitas - valorDespesas;

            var usuarioDbContext = _context.Usuarios.Where(i => i.Email == userEmail);
            return View(await usuarioDbContext.ToListAsync());
        }

        private string GetAlertClass(decimal porcentagemDespesas)
        {
            if (porcentagemDespesas > 95)
            {
                return "alert-danger";
            }
            else if (porcentagemDespesas > 85 && porcentagemDespesas <= 95)
            {
                return "alert-orange";
            }
            else if (porcentagemDespesas >= 75 && porcentagemDespesas <= 85)
            {
                return "alert-warning";
            }

            return string.Empty;
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
                usuario.Conta = account;
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
