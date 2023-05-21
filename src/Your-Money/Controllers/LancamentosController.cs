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

            var alimentoReceita = CountLancamentosByClassificacao(Classificacao.Alimentação, Transacao.Receita, mes, ano);
            var veiculosReceita = CountLancamentosByClassificacao(Classificacao.Veículo, Transacao.Receita, mes, ano);
            var salariosReceita = CountLancamentosByClassificacao(Classificacao.Salário, Transacao.Receita, mes, ano);

            var alimentoDespesa = CountLancamentosByClassificacao(Classificacao.Alimentação, Transacao.Despesa, mes, ano);
            var veiculosDespesa = CountLancamentosByClassificacao(Classificacao.Veículo, Transacao.Despesa, mes, ano);
            var salariosDespesa = CountLancamentosByClassificacao(Classificacao.Salário, Transacao.Despesa, mes, ano);
            var moradiasDespesa = CountLancamentosByClassificacao(Classificacao.Moradia, Transacao.Despesa, mes, ano);
            var transportesDespesa = CountLancamentosByClassificacao(Classificacao.Transporte, Transacao.Despesa, mes, ano);
            var emprestimosDespesa = CountLancamentosByClassificacao(Classificacao.Empréstimos, Transacao.Despesa, mes, ano);
            var entretenimentosDespesa = CountLancamentosByClassificacao(Classificacao.Entretenimento, Transacao.Despesa, mes, ano);
            var impostosDespesa = CountLancamentosByClassificacao(Classificacao.Impostos, Transacao.Despesa, mes, ano);
            var taxasDespesa = CountLancamentosByClassificacao(Classificacao.Taxas, Transacao.Despesa, mes, ano);
            var saudeDespesa = CountLancamentosByClassificacao(Classificacao.Saúde, Transacao.Despesa, mes, ano);

            ViewBag.AlimentacaoReceita = alimentoReceita;
            ViewBag.VeiculoReceita = veiculosReceita;
            ViewBag.SalarioReceita = salariosReceita;

            ViewBag.AlimentacaoDespesa = alimentoDespesa;
            ViewBag.VeiculoDespesa = veiculosDespesa;
            ViewBag.SalarioDespesa = salariosDespesa;
            ViewBag.MoradiaDespesa = moradiasDespesa;
            ViewBag.TransporteDespesa = transportesDespesa;
            ViewBag.EmprestimoDespesa = emprestimosDespesa;
            ViewBag.EntretenimentoDespesa = entretenimentosDespesa;
            ViewBag.ImpostoDespesa = impostosDespesa;
            ViewBag.TaxaDespesa = taxasDespesa;
            ViewBag.SaudeDespesa = saudeDespesa;


            return View(await applicationDbContext.ToListAsync());
        }
        private decimal CountLancamentosByClassificacao(Classificacao classificacao, Transacao transacao, int? mes, int? ano)
        {
            var userEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email)?.Value;
            return _context.Lancamentos
                .Where(t => t.Classificacao == classificacao &&
                            t.Tipo == transacao &&
                            t.Data.Month == mes &&
                            t.Data.Year == ano &&
                            t.Contas.Usuario.Email == userEmail)
                .Sum(l => l.Valor);
        }

        /*
        public async Task<IActionResult> RelatorioDescritvo(DateTime dataInicial, DateTime dataFinal, int? status, int? transacao)
        {
            var userEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email)?.Value;
            var lancamentos = _context.Lancamentos
                .Where(l => l.Contas.Usuario.Email == userEmail &&
                    l.Data >= dataInicial && l.Data <= dataFinal &&
                    (status == null || (int)l.Status == status) &&
                    (transacao == null || (int)l.Tipo == transacao));

            

            return View(await lancamentos.ToListAsync());
        }
        */


        // Gráficos1
        public (int receitasMes, int despesasMes) GetLancamentosMes(int? mes, int? ano)
        {
            var userEmail = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email)?.Value;
            int contagemDeLancamentosReceita = 0;
            int contagemDeLancamentosDespesas = 0;

            

            foreach (var lancamento in _context.Lancamentos.Where(l => l.Data.Month == mes &&
                                                                      l.Data.Year == ano &&
                                                                      l.Tipo == Transacao.Receita &&
                                                                      l.Contas.Usuario.Email == userEmail))
            {
                contagemDeLancamentosReceita += 1;
            }

            foreach (var lancamento in _context.Lancamentos.Where(l => l.Data.Month == mes &&
                                                                      l.Data.Year == ano &&
                                                                      l.Tipo == Transacao.Despesa &&
                                                                      l.Contas.Usuario.Email == userEmail))
            {
                contagemDeLancamentosDespesas += 1;
            }

            //Pega saldo total do ano
            var saldoTotalAno = _context.Lancamentos.Where(l => l.Contas.Usuario.Email == userEmail &&
                                                                l.Status == StatusTransacao.Efetivado &&
                                                                l.Data.Year == ano).Sum(l => l.Tipo == Transacao.Receita ? l.Valor : -l.Valor);

            ViewBag.SaldoTotalAno = saldoTotalAno;
            //

            return (contagemDeLancamentosReceita, contagemDeLancamentosDespesas);
        }
        //

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