using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Your_Money.Models
{
    [Table("Lancamentos")]
    public class Lancamento
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Transação")]
        [Required(ErrorMessage = "Obrigatório informar a Transação!")]
        public Transacao Tipo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a via!")]
        public Via Via { get; set; }

        [Display(Name = "Classificação")]
        [Required(ErrorMessage = "Obrigatório informar a classificação!")]
        public Classificacao Classificacao { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "É necessário informar o valor!")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data!")]
        [Display(Name = "Data de Vencimento")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o status!")]
        public StatusTransacao Status { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Obrigatório informar a descrição!")]
        public string Descricao { get; set; }

        [Display(Name = "Recorrente?")]
        [Required(ErrorMessage = "Obrigatório informar o número de parcelas! Caso não haja parcela, coloque 0")]
        public int NumeroParcelas { get; set; }
        public int ParcelaAtual { get; set; }

        public int ContasId { get; set; }
        
        [ForeignKey("ContasId")]
        public Conta Contas { get; set; }

        public List<Parcelamento> Parcelamentos { get; set; }
    }

    public enum StatusTransacao
    { 
        Pendente,
        Efetivado
    }

    public enum Transacao
    {
        Receita,
        Despesa
    }

    public enum Via
    {
        Dinheiro,
        Transferência,
        Pix
    }

    public enum Classificacao
    {
        Alimentação,
        CartãoDeCrédito,
        Educação,
        Empréstimos,
        Entretenimento,
        Eventos,
        Impostos,
        Imprevistos,
        Investimentos,
        Moradia,
        Salário,
        Saúde,
        Seguros,
        Taxas,
        Transporte,
        Veículo,
        Vestuário,
        Outros
    }
}