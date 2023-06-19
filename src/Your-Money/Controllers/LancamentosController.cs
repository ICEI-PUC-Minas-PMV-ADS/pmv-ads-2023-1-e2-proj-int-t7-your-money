using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Your_Money.Models;

namespace Your_Money.Controllers
{
    [Authorize]
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
                .Include(p => p.Parcelamentos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (lancamento == null)
            {
                return NotFound();
            }

            return View(lancamento);
        }

        // GET: Lancamentos/Relatorio/5
        public async Task<IActionResult> Relatorio(int? mes, int? ano)
        {
            var userEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email)?.Value;
            var applicationDbContext = _context.Lancamentos.Where(i => i.Contas.Usuario.Email == userEmail);

            //Gráficos
            if (mes == null)
            {
                mes = DateTime.Now.Month;
            }
            if (ano == null)
            {
                ano = DateTime.Now.Year;
            }

            ViewBag.AnoAtual = ano;

            int mesAtual = DateTime.Now.Month;

            ViewBag.MesAtual = mesAtual;

            Dictionary<int, (int receitasMes, int despesasMes)> lancamentosMes = new Dictionary<int, (int, int)>();

            for (int mesRelatorio = 1; mesRelatorio <= 12; mesRelatorio++)
            {
                var (receitasMes, despesasMes) = GetLancamentosMes(mesRelatorio, ano);
                lancamentosMes[mesRelatorio] = (receitasMes, despesasMes);
            }

            ViewBag.LancamentosMes = lancamentosMes;

            var salarioReceita = SomaLancamentosPorClassificacao(Classificacao.Salário, Transacao.Receita, mes, ano);
            var investimentoReceita = SomaLancamentosPorClassificacao(Classificacao.Investimentos, Transacao.Receita, mes, ano);
            var outroReceita = SomaLancamentosPorClassificacao(Classificacao.Outros, Transacao.Receita, mes, ano);

            var alimentoDespesa = SomaLancamentosPorClassificacao(Classificacao.Alimentação, Transacao.Despesa, mes, ano);
            var veiculosDespesa = SomaLancamentosPorClassificacao(Classificacao.Veículo, Transacao.Despesa, mes, ano);
            var moradiasDespesa = SomaLancamentosPorClassificacao(Classificacao.Moradia, Transacao.Despesa, mes, ano);
            var transportesDespesa = SomaLancamentosPorClassificacao(Classificacao.Transporte, Transacao.Despesa, mes, ano);
            var emprestimosDespesa = SomaLancamentosPorClassificacao(Classificacao.Empréstimos, Transacao.Despesa, mes, ano);
            var entretenimentosDespesa = SomaLancamentosPorClassificacao(Classificacao.Entretenimento, Transacao.Despesa, mes, ano);
            var impostosDespesa = SomaLancamentosPorClassificacao(Classificacao.Impostos, Transacao.Despesa, mes, ano);
            var taxasDespesa = SomaLancamentosPorClassificacao(Classificacao.Taxas, Transacao.Despesa, mes, ano);
            var saudeDespesa = SomaLancamentosPorClassificacao(Classificacao.Saúde, Transacao.Despesa, mes, ano);
            var educacaoDespesa = SomaLancamentosPorClassificacao(Classificacao.Educação, Transacao.Despesa, mes, ano);
            var segurosDespesa = SomaLancamentosPorClassificacao(Classificacao.Seguros, Transacao.Despesa, mes, ano);
            var vestuarioDespesa = SomaLancamentosPorClassificacao(Classificacao.Vestuário, Transacao.Despesa, mes, ano);
            var investimentosDespesa = SomaLancamentosPorClassificacao(Classificacao.Investimentos, Transacao.Despesa, mes, ano);
            var imprevistosDespesa = SomaLancamentosPorClassificacao(Classificacao.Imprevistos, Transacao.Despesa, mes, ano);
            var eventosDespesa = SomaLancamentosPorClassificacao(Classificacao.Eventos, Transacao.Despesa, mes, ano);
            var outrosDespesa = SomaLancamentosPorClassificacao(Classificacao.Outros, Transacao.Despesa, mes, ano);

            ViewBag.SalarioReceita = salarioReceita;
            ViewBag.InvestimentosReceita = investimentoReceita;
            ViewBag.OutrosReceita = outroReceita;

            ViewBag.AlimentacaoDespesa = alimentoDespesa;
            ViewBag.VeiculoDespesa = veiculosDespesa;
            ViewBag.MoradiaDespesa = moradiasDespesa;
            ViewBag.TransporteDespesa = transportesDespesa;
            ViewBag.EmprestimoDespesa = emprestimosDespesa;
            ViewBag.EntretenimentoDespesa = entretenimentosDespesa;
            ViewBag.ImpostoDespesa = impostosDespesa;
            ViewBag.TaxaDespesa = taxasDespesa;
            ViewBag.SaudeDespesa = saudeDespesa;
            ViewBag.EducacaoDespesa = educacaoDespesa;
            ViewBag.SegurosDespesa = segurosDespesa;
            ViewBag.VestuarioDespesa = vestuarioDespesa;
            ViewBag.InvestimentosDespesa = investimentosDespesa;
            ViewBag.ImprevistosDespesa = imprevistosDespesa;
            ViewBag.EventosDespesa = eventosDespesa;
            ViewBag.OutrosDespesa = outrosDespesa;

            return View(await applicationDbContext.ToListAsync());
        }

        // Gráficos1
        public (int receitasMes, int despesasMes) GetLancamentosMes(int? mes, int? ano)
        {
            var userEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email)?.Value;
            decimal somaDeLancamentosReceita = 0;
            decimal somaDeLancamentoDespesas = 0;

            foreach (var lancamento in _context.Lancamentos.Where(l => l.Data.Month == mes &&
                                                                      l.Data.Year == ano &&
                                                                      l.Tipo == Transacao.Receita &&
                                                                      l.Status == StatusTransacao.Efetivado &&
                                                                      l.Contas.Usuario.Email == userEmail))
            {
                somaDeLancamentosReceita += lancamento.Valor;
            }

            foreach (var lancamento in _context.Lancamentos.Where(l => l.Data.Month == mes &&
                                                                      l.Data.Year == ano &&
                                                                      l.Tipo == Transacao.Despesa &&
                                                                      l.Status == StatusTransacao.Efetivado &&
                                                                      l.Contas.Usuario.Email == userEmail))
            {
                somaDeLancamentoDespesas += lancamento.Valor;
            }

            // Pega saldo total do ano
            var saldoTotalAno = _context.Lancamentos.Where(l => l.Contas.Usuario.Email == userEmail &&
                                                                l.Status == StatusTransacao.Efetivado &&
                                                                l.Data.Year == ano).Sum(l => l.Tipo == Transacao.Receita ? l.Valor : -l.Valor);

            ViewBag.SaldoTotalAno = saldoTotalAno;
            //

            return ((int)Math.Round(somaDeLancamentosReceita), (int)Math.Round(somaDeLancamentoDespesas));
        }
        private decimal SomaLancamentosPorClassificacao(Classificacao classificacao, Transacao transacao, int? mes, int? ano)
        {
            var userEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email)?.Value;
            var result = _context.Lancamentos
                .Where(t => t.Classificacao == classificacao &&
                            t.Tipo == transacao &&
                            t.Data.Month == mes &&
                            t.Data.Year == ano &&
                            t.Status == StatusTransacao.Efetivado &&
                            t.Contas.Usuario.Email == userEmail)
                .Sum(t => t.Valor);
            return (int)Math.Round(result);
        }

        // GET: Lancamentos/Create
        public IActionResult Create()
        {
            ViewData["ContasId"] = new SelectList(new List<Usuario> { GetUser() }, "Id", "Email");
            return View();
        }

        // POST: Lancamentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Via,Classificacao,Valor,Data,Status,Descricao,ContasId,NumeroParcelas")] Lancamento lancamento)
        {
            if (ModelState.IsValid)
            {
                lancamento.ContasId = GetUser().Id;
                lancamento.ParcelaAtual = lancamento.NumeroParcelas == 0 ? 0 : 1;

                _context.Add(lancamento);
                await _context.SaveChangesAsync();

                if (lancamento.NumeroParcelas > 1)
                {
                    decimal valorParcela = lancamento.Valor / lancamento.NumeroParcelas;

                    for (int parcela = 1; parcela <= lancamento.NumeroParcelas; parcela++)
                    {
                        var parcelamento = new Parcelamento()
                        {
                            LancamentoId =  lancamento.Id,
                            Valor = valorParcela,
                            DataPagamento = null,
                            DataVencimento = lancamento.Data.AddMonths(parcela - 1),
                            Status = false
                        };

                        _context.Add(parcelamento);
                    }
                }

                var usuario = await _context.Conta.Include(u => u.Lancamentos).FirstOrDefaultAsync(u => u.Id == lancamento.ContasId);
                if (lancamento.Status == StatusTransacao.Efetivado)
                {
                    usuario.SaldoTotal += lancamento.Tipo == Transacao.Despesa ? -lancamento.Valor : lancamento.Valor;
                }

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

            var lancamento = await _context.Lancamentos
                .Include(l => l.Contas)
                .Include(p => p.Parcelamentos)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (lancamento == null)
            {
                return NotFound();
            }

            ViewData["ContasId"] = new SelectList(new List<Usuario> { GetUser() }, "Id", "Email");
            return View(lancamento);
        }

        // POST: Lancamentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Via,Classificacao,Valor,Data,Status,Descricao,ContasId,NumeroParcelas")] Lancamento lancamento)
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
                    if (lancamento.Status == StatusTransacao.Efetivado)
                    {
                        usuario.SaldoTotal = usuario.Lancamentos.Sum(l => l.Tipo == Transacao.Despesa ? -l.Valor : l.Valor);
                    }
                    if (lancamento.Status == StatusTransacao.Pendente)
                    {
                        usuario.SaldoTotal = usuario.Lancamentos.Where(l => l.Id != id).Sum(l => l.Valor);
                    }

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
                .Include(p => p.Parcelamentos)
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