using ListaDeContatos.Data;
using ListaDeContatos.Models;
using System.Collections.Generic;
using System.Linq;

namespace ListaDeContatos.Repositorio
{
    // Classe responsável por acessar e manipular os dados dos contatos no banco de dados
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _context; // Contexto do banco de dados

        // Construtor da classe, recebe o contexto do banco de dados como parâmetro
        public ContatoRepositorio(BancoContext bancoContext)
        {
            this._context = bancoContext;
        }

        // Método para buscar um contato pelo seu ID
        public ContatoModel ListarPorId(int id)
        {
            return _context.Contatos.FirstOrDefault(x => x.Id == id);
        }

        // Método para buscar todos os contatos
        public List<ContatoModel> BuscarTodos()
        {
            return _context.Contatos.ToList();
        }

        // Método para adicionar um novo contato ao banco de dados
        public ContatoModel Adicionar(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        // Método para atualizar um contato existente no banco de dados
        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarPorId(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na atualização do Contato! ");

            // Atualiza os dados do contato existente com os novos dados
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Telefone = contato.Telefone;
            contatoDB.Endereco = contato.Endereco;

            _context.Contatos.Update(contatoDB); // Atualiza o registro no banco de dados
            _context.SaveChanges(); // Salva as mudanças

            return contatoDB; // Retorna o contato atualizado
        }

        // Método para apagar um contato do banco de dados
        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarPorId(id);
            if (contatoDB == null) throw new System.Exception("Houve um erro ao Deletar o Contato!");

            // Remove o contato do contexto e do banco de dados
            _context.Contatos.Remove(contatoDB);
            _context.SaveChanges();

            return true; // Retorna verdadeiro indicando que o contato foi removido com sucesso
        }
    }
}
