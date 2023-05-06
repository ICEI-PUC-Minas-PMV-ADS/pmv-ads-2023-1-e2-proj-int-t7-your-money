using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Your_Money.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "É necessário informar um nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário informar um e-mail")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário informar uma senha!")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public Conta conta { get; set; }

        public ICollection<Lancamento> Lancamentos { get; set; }
    }
}
