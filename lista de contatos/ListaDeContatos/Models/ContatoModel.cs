using System;
using System.ComponentModel.DataAnnotations;

namespace ListaDeContatos.Models
{
    // Definição da classe 'ContatoModel' que representa um contato no sistema
    public class ContatoModel
    {
        // Propriedade 'Id' com tipo 'int' e atributos 'get' e 'set'
        public int Id { get; set; }

        // Propriedade 'Nome' com validação para campo obrigatório
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Nome { get; set; }

        // Propriedade 'Email' com validação para campo obrigatório e formato de e-mail
        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        public string Email { get; set; }

        // Propriedade 'Telefone' com validação para campo obrigatório e formato de telefone
        [Required(ErrorMessage = "Digite o telefone do contato")]
        [Phone(ErrorMessage = "O telefone informado não é válido!")]
        public string Telefone { get; set; }

        // Propriedade 'Endereco' com validação para campo obrigatório
        [Required(ErrorMessage = "Digite o endereço do contato")]
        public string Endereco { get; set; }
    }
}
