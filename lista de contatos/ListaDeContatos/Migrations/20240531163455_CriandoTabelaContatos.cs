using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ListaDeContatos.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaContatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Método para aplicar a migração, criando a tabela 'Contatos'
            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    // Definição da coluna 'Id' como chave primária com incremento automático
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    // Definição da coluna 'Nome' como string não nula
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    // Definição da coluna 'Email' como string não nula
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    // Definição da coluna 'Telefone' como string não nula
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    // Definição da coluna 'Endereco' como string não nula
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                // Definindo a chave primária da tabela 'Contatos'
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Método para reverter a migração, excluindo a tabela 'Contatos'
            migrationBuilder.DropTable(
                name: "Contatos");
        }
    }
}
