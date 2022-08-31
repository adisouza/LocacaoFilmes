using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocacaoFilmes.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataNascimento = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClassificacaoIndicativa = table.Column<int>(type: "int", nullable: false),
                    Lancamento = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Locacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_Cliente = table.Column<int>(type: "int", nullable: true),
                    Id_Filme = table.Column<int>(type: "int", nullable: true),
                    DataLocacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacao", x => x.Id);
                    //table.ForeignKey(
                    //    name: "FK_Cliente_idx",
                    //    column: x => x.FK_Cliente_idx,
                    //    principalTable: "Cliente",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Restrict);
                    //table.ForeignKey(
                    //    name: "FK_Filme_idx",
                    //    column: x => x.FK_Filme_idx,
                    //    principalTable: "Filme",
                    //    principalColumn: "Id",
                    //    onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "FK_Cliente_idx",
                table: "Locacao",
                column: "Id_Cliente");

            migrationBuilder.CreateIndex(
                name: "FK_Filme_idx",
                table: "Locacao",
                column: "Id_Filme");

            migrationBuilder.CreateIndex(
              name: "idx_CPF",
              table: "Cliente",
              column: "CPF");
            migrationBuilder.CreateIndex(
              name: "idx_Nome",
              table: "Cliente",
              column: "Nome");
            migrationBuilder.CreateIndex(
              name: "idx_Lancamento",
              table: "Filme",
              column: "Lancamento");
            migrationBuilder.CreateIndex(
              name: "idx_Titulo",
              table: "Filme",
              column: "Titulo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Filme");
        }
    }
}
