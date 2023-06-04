using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Your_Money.Models;


namespace Your_Money.Controllers
{
    public class ParcelamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParcelamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parcelamentos/Details/id
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcelamento = await _context.Parcelamentos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (parcelamento == null)
            {
                return NotFound();
            }

            return View(parcelamento);
        }

        // GET: Parcelamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcelamento = await _context.Parcelamentos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (parcelamento == null)
            {
                return NotFound();
            }

            return View(parcelamento);
        }

        // POST: Parcelamentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LancamentoId,Valor,DataPagamento,DataVencimento,Status")] Parcelamento parcelamento)
        {
            if (id != parcelamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(parcelamento);
                await _context.SaveChangesAsync();

                var lancamento = await _context.Lancamentos
                    .Include(l => l.Contas)
                    .Include(p => p.Parcelamentos)
                    .FirstOrDefaultAsync(m => m.Id == parcelamento.LancamentoId);

                var todasParcelasPagas = lancamento.Parcelamentos.Count == lancamento.Parcelamentos.Where(x => x.Status == true).ToList().Count;
                if (todasParcelasPagas)
                    lancamento.Status = StatusTransacao.Efetivado;
                else
                {
                    foreach (var p in lancamento.Parcelamentos)
                        if (p.Status == false)
                        {
                            lancamento.Data = p.DataVencimento;
                            break;
                        }

                    lancamento.Status = StatusTransacao.Pendente;
                }

                _context.Update(lancamento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", "Lancamentos", new { id = parcelamento.LancamentoId });
            }

            return View(parcelamento);
        }

        // GET: Parcelamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parcelamento = await _context.Parcelamentos
                .FirstOrDefaultAsync(p => p.Id == id);

            if (parcelamento == null)
            {
                return NotFound();
            }

            return View(parcelamento);
        }

        // POST: Parcelamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parcelamento = await _context.Parcelamentos.FindAsync(id);
            _context.Parcelamentos.Remove(parcelamento);
            await _context.SaveChangesAsync();
            return RedirectToAction("Edit", "Lancamentos", new { id = parcelamento.LancamentoId });
        }
    }
}