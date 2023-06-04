using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
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

        [Required(ErrorMessage = "É necessário inserir um nome!")]
        [Display(Name = "Nome *")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário inserir um e-mail!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail *")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário inserir uma senha!")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).*$", ErrorMessage = "A senha deve conter letras maiúsculas, minúsculas e pelo menos um número.")]
        [DataType(DataType.Password)]
        [Display(Name = "Insira sua Senha *")]
        public string Senha { get; set; }

        [NotMapped]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).*$", ErrorMessage = "A senha deve conter letras maiúsculas, minúsculas e pelo menos um número.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirme sua Senha *")]
        public string ConfirmarSenha { get; set; }

        /*Variável inutilizada até o momento.
        public string TokenRecuperacaoSenha { get; set; }*/

        public string CodigoTemporario { get; set; }



        public Conta conta { get; set; }

        internal bool ConfirmacaoSenha()
        {
            return Senha == ConfirmarSenha;
        }



        /*Código inutilizado até o momento.
        public void GerarTokenRecuperacaoSenha()
        {
            TokenRecuperacaoSenha = Guid.NewGuid().ToString();
        }*/
    }
}
