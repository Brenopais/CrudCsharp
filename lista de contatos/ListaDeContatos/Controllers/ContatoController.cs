using System.Collections.Generic;
using ListaDeContatos.Models;
using ListaDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        // Construtor que injeta a dependência do repositório de contatos
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        // Ação que exibe a lista de contatos
        public IActionResult Index()
        {
            // Busca todos os contatos no repositório
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            // Retorna a view com a lista de contatos
            return View(contatos);
        }

        // Ação que exibe a página de criação de contato
        public IActionResult Criar()
        {
            return View();
        }

        // Ação que exibe a página de edição de contato
        public IActionResult Editar(int id)
        {
            // Busca o contato pelo ID
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            // Retorna a view com os dados do contato
            return View(contato);
        }

        // Ação que exibe a página de confirmação de exclusão de contato
        public IActionResult ApagarConfirmacao(int id)
        {
            // Busca o contato pelo ID
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            // Retorna a view com os dados do contato
            return View(contato);
        }

        // Ação que apaga um contato
        public IActionResult Apagar(int id)
        {
            try
            {
                // Tenta apagar o contato no repositório
                bool apagado = _contatoRepositorio.Apagar(id);

                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                }
                else
                {
                    TempData["MensagemErro"] = "Ops, não conseguimos apagar seu contato!";
                }
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, mais detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // Ação POST que cria um novo contato
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                // Verifica se o modelo é válido
                if (ModelState.IsValid)
                {
                    // Adiciona o contato no repositório
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                // Se o modelo não é válido, retorna à view com os dados do contato
                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        // Ação POST que altera um contato existente
        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                // Verifica se o modelo é válido
                if (ModelState.IsValid)
                {
                    // Atualiza o contato no repositório
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                // Se o modelo não é válido, retorna à view de edição com os dados do contato
                return View("Editar", contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos Atualizar seu contato, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
