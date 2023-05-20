using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Your_Money.Models;

namespace Your_Money.Controllers
{
    public class LancamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LancamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lancamentos
        public async Task<IActionResult> Index()
        {
            var userEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email)?.Value;
            var applicationDbContext = _context.Lancamentos.Where(i => i.Contas.Usuario.Email == userEmail);
            return View(await applicationDbContext.ToListAsync());
        }

        private Usuario GetUser()
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).Value);
        }

        // GET: Lancamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lancamento = await _context.Lancamentos
                .Include(l => l.Contas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lancamento == null)
            {
                return NotFound();
            }

            return View(lancamento);
        }

        /*
        // GET: Lancamentos/Relatorio/5
        public async Task<IActionResult> Relatorio()
        {
            var userEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email)?.Value;
            var applicationDbContext = _context.Lancamentos.Where(i => i.Contas.Usuario.Email == userEmail);
            return View(await applicationDbContext.ToListAsync());
        }
        */

        public async Task<IActionResult> Relatorio(DateTime dataInicial, DateTime dataFinal, int? status, int? transacao)
        {
            var userEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email)?.Value;
            var lancamentos = _context.Lancamentos
                .Where(l => l.Contas.Usuario.Email == userEmail &&
                    l.Data >= dataInicial && l.Data <= dataFinal &&
                    (status == null || (int)l.Status == status) &&
                    (transacao == null || (int)l.Tipo == transacao));

            return View(await lancamentos.ToListAsync());
        }

        // GET: Lancamentos/Create
        public IActionResult Create()
        {
            ViewData["ContasId"] = new SelectList(new List<Usuario> { GetUser() }, "Id", "Email");
            return View();
        }

        // POST: Lancamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Via,Classificacao,Valor,Data,Status,Descricao,ContasId")] Lancamento lancamento)
        {
            if (ModelState.IsValid)
            {
                lancamento.ContasId = GetUser().Id;
                _context.Add(lancamento);
                await _context.SaveChangesAsync();

                var usuario = await _context.Conta.Include(u => u.Lancamentos).FirstOrDefaultAsync(u => u.Id == lancamento.ContasId);
                usuario.SaldoTotal += lancamento.Tipo == Transacao.Despesa ? -lancamento.Valor : lancamento.Valor;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        ViewData["ContasId"] = new SelectList(new List<Usuario> { GetUser() }, "Id", "Email");
            return View(lancamento);
        }



        // GET: Lancamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento == null)
            {
                return NotFound();
            }
            ViewData["ContasId"] = new SelectList(new List<Usuario> { GetUser() }, "Id", "Email");
            return View(lancamento);
        }

        // POST: Lancamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Via,Classificacao,Valor,Data,Status,Descricao,ContasId")] Lancamento lancamento)
        {
            if (id != lancamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    lancamento.ContasId = GetUser().Id;
                    _context.Update(lancamento);
                    await _context.SaveChangesAsync();

                    var usuario = await _context.Conta.Include(u => u.Lancamentos).FirstOrDefaultAsync(u => u.Id == lancamento.ContasId);
                    usuario.SaldoTotal = usuario.Lancamentos.Sum(l => l.Tipo == Transacao.Despesa ? -l.Valor : l.Valor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LancamentoExists(lancamento.Id))
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
            ViewData["ContasId"] = new SelectList(new List<Usuario> { GetUser() }, "Id", "Email");
            return View(lancamento);
        }

        // GET: Lancamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lancamento = await _context.Lancamentos
                .Include(l => l.Contas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lancamento == null)
            {
                return NotFound();
            }

            return View(lancamento);
        }

        // POST: Lancamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);

            if (lancamento != null)
            {
                var usuario = await _context.Conta.Include(u => u.Lancamentos).FirstOrDefaultAsync(u => u.Id == lancamento.ContasId);
                usuario.SaldoTotal = usuario.Lancamentos.Where(l => l.Id != id).Sum(l => l.Valor);

                _context.Lancamentos.Remove(lancamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LancamentoExists(int id)
        {
            return _context.Lancamentos.Any(e => e.Id == id);
        }
    }
}
