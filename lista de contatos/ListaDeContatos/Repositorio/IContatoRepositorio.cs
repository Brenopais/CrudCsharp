using ListaDeContatos.Models; 
using System.Collections.Generic;

namespace ListaDeContatos.Repositorio 
{
    public interface IContatoRepositorio 
    {
        // Método para buscar um contato por ID
        ContatoModel ListarPorId(int id); // Retorna um objeto 'ContatoModel' que corresponde ao ID passado

        // Método para buscar todos os contatos
        List<ContatoModel> BuscarTodos(); // Retorna uma lista de objetos 'ContatoModel' representando todos os contatos

        // Método para adicionar um novo contato
        ContatoModel Adicionar(ContatoModel contato); // Recebe um objeto 'ContatoModel' como parâmetro e retorna o mesmo objeto após adicioná-lo ao armazenamento

        // Método para atualizar as informações de um contato
        ContatoModel Atualizar(ContatoModel contato); // Recebe um objeto 'ContatoModel' como parâmetro e retorna o mesmo objeto após atualizar suas informações no armazenamento

        // Método para remover um contato pelo ID
        bool Apagar(int id); // Recebe um ID como parâmetro e retorna 'true' se a operação de remoção for bem-sucedida
    }
}
