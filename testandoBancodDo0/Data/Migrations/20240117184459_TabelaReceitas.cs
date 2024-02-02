using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace testandoBancodDo0.Data.Migrations
{
    /// <inheritdoc />
    public partial class TabelaReceitas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tab_ingredientes",
                columns: table => new
                {
                    idIngredientes = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<string>(type: "text", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_ingredientes", x => x.idIngredientes);
                });

            migrationBuilder.CreateTable(
                name: "tab_sugestaoRec",
                columns: table => new
                {
                    idSugestao = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    ModoPreparo = table.Column<string>(type: "text", nullable: false),
                    Ingredientes = table.Column<string>(type: "text", nullable: false),
                    Id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_sugestaoRec", x => x.idSugestao);
                    table.ForeignKey(
                        name: "FK_tab_sugestaoRec_usuarios_Id",
                        column: x => x.Id,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tab_receitas",
                columns: table => new
                {
                    idReceita = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    ModoPreparo = table.Column<string>(type: "text", nullable: false),
                    idIngredientes = table.Column<int>(type: "integer", nullable: false),
                    idSugestao = table.Column<int>(type: "integer", nullable: false),
                    SugestaoReceitaidSugestao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_receitas", x => x.idReceita);
                    table.ForeignKey(
                        name: "FK_tab_receitas_tab_ingredientes_idIngredientes",
                        column: x => x.idIngredientes,
                        principalTable: "tab_ingredientes",
                        principalColumn: "idIngredientes",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tab_receitas_tab_sugestaoRec_SugestaoReceitaidSugestao",
                        column: x => x.SugestaoReceitaidSugestao,
                        principalTable: "tab_sugestaoRec",
                        principalColumn: "idSugestao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tab_receitas_idIngredientes",
                table: "tab_receitas",
                column: "idIngredientes");

            migrationBuilder.CreateIndex(
                name: "IX_tab_receitas_SugestaoReceitaidSugestao",
                table: "tab_receitas",
                column: "SugestaoReceitaidSugestao");

            migrationBuilder.CreateIndex(
                name: "IX_tab_sugestaoRec_Id",
                table: "tab_sugestaoRec",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tab_receitas");

            migrationBuilder.DropTable(
                name: "tab_ingredientes");

            migrationBuilder.DropTable(
                name: "tab_sugestaoRec");
        }
    }
}
