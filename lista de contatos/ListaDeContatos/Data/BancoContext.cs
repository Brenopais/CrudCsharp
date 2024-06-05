using ListaDeContatos.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeContatos.Data
{
    // Classe que representa o contexto do banco de dados usando Entity Framework Core
    public class BancoContext : DbContext
    {
        // Construtor que aceita opções de configuração para o DbContext
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        // DbSet que representa a tabela de contatos no banco de dados
        public DbSet<ContatoModel> Contatos { get; set; }
    }
}
