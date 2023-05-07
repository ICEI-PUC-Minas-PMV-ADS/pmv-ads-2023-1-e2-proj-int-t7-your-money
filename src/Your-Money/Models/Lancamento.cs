using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using System.Globalization;
using Microsoft.VisualBasic;
using Microsoft.AspNetCore.Components.Forms;

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
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = true)]
        public decimal Valor { get; set; }

        [Display(Name = "Data de Vencimento")]
        [Required(ErrorMessage = "Obrigatório informar a data!")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o status!")]
        public StatusTransacao Status { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Obrigatório informar a descrição!")]
        public string Descricao { get; set; }


        public int ContasId { get; set; }
        
        [ForeignKey("ContasId")]
        public Conta Contas { get; set; }
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
        Cartão,
        Pix
    }
    public enum Classificacao
    {
        Alimentação,
        Veículo,
        Salário,
        Moradia,
        Transporte,
        Empréstimos,
        Entretenimento,
        Impostos,
        Taxas,
        Saúde

    }
}
