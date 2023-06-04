using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Your_Money.Models
{
    [Table("Parcelamentos")]
    public class Parcelamento
    {
        [Key]
        public int Id { get; set; }

        public int LancamentoId { get; set; }

        [ForeignKey("LancamentoId")]
        public Lancamento Lancamento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "É necessário informar o valor!")]
        [DataType(DataType.Currency)]
        public decimal Valor { get; set; }

        [Display(Name = "Data de Pagamento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataPagamento { get; set; }

        [Display(Name = "Data de Vencimento")]
        [Required(ErrorMessage = "Obrigatório informar a data!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVencimento { get; set; }

        public bool Status { get; set; }
    }
}