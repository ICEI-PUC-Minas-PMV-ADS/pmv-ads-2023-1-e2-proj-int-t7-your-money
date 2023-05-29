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

            lancamento.Parcelamentos = _context.Parcelamentos
                .Where(x => x.LancamentoId == lancamento.Id).ToList();

            return View(lancamento);
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

            lancamento.Parcelamentos = _context.Parcelamentos
                .Where(x => x.LancamentoId == lancamento.Id).ToList();

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

            lancamento.Parcelamentos = _context.Parcelamentos
                .Where(x => x.LancamentoId == lancamento.Id).ToList();

            return View(lancamento);
        }

        // POST: Lancamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            _context.Lancamentos.Remove(lancamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LancamentoExists(int id)
        {
            return _context.Lancamentos.Any(e => e.Id == id);
        }
    }
}
