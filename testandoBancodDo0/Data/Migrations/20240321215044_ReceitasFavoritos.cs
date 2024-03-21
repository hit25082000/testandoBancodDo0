using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace testandoBancodDo0.Data.Migrations
{
    /// <inheritdoc />
    public partial class ReceitasFavoritos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "cad_receitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Ingredientes = table.Column<string>(type: "text", nullable: false),
                    ModoPreparo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cad_receitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tab_ingredientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<string>(type: "text", nullable: false),
                    UnidadeMedida = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tab_ingredientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
               name: "tab_sugestaoRec",
               columns: table => new
               {
                   Id = table.Column<int>(type: "integer", nullable: false)
                       .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                   Titulo = table.Column<string>(type: "text", nullable: false),
                   Descricao = table.Column<string>(type: "text", nullable: false),
                   ModoPreparo = table.Column<string>(type: "text", nullable: false),
                   Ingredientes = table.Column<string>(type: "text", nullable: false),
                   UsuarioId = table.Column<string>(type: "text", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_tab_sugestaoRec", x => x.Id);
                   table.ForeignKey(
                       name: "FK_tab_sugestaoRec_usuarios_UsuarioId",
                       column: x => x.UsuarioId,
                       principalTable: "usuarios",
                       principalColumn: "Id",
                       onDelete: ReferentialAction.Cascade);
               });


            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    ModoPreparo = table.Column<string>(type: "text", nullable: false),
                    IdIngredientes = table.Column<int>(type: "integer", nullable: false),
                    IdSugestao = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receitas_tab_ingredientes_IdIngredientes",
                        column: x => x.IdIngredientes,
                        principalTable: "tab_ingredientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receitas_tab_sugestaoRec_IdSugestao",
                        column: x => x.IdSugestao,
                        principalTable: "tab_sugestaoRec",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });



            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.Id);
                });



            migrationBuilder.CreateTable(
                name: "FavoritoReceita",
                columns: table => new
                {
                    FavoritosId = table.Column<int>(type: "integer", nullable: false),
                    ReceitasId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoritoReceita", x => new { x.FavoritosId, x.ReceitasId });
                    table.ForeignKey(
                        name: "FK_FavoritoReceita_Favoritos_FavoritosId",
                        column: x => x.FavoritosId,
                        principalTable: "Favoritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoritoReceita_Receitas_ReceitasId",
                        column: x => x.ReceitasId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoritoReceita_ReceitasId",
                table: "FavoritoReceita",
                column: "ReceitasId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_IdIngredientes",
                table: "Receitas",
                column: "IdIngredientes");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_IdSugestao",
                table: "Receitas",
                column: "IdSugestao");

            migrationBuilder.CreateIndex(
                name: "IX_tab_sugestaoRec_UsuarioId",
                table: "tab_sugestaoRec",
                column: "UsuarioId");


            migrationBuilder.CreateIndex(
                name: "IX_tab_sugestaoRec_Id",
                table: "tab_sugestaoRec",
                column: "Id");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "FavoritoReceita");

            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "tab_sugestaoRec");

            migrationBuilder.DropTable(
                name: "cad_receitas");

            migrationBuilder.DropTable(
                name: "tab_ingredientes");

            migrationBuilder.DropTable(
                name: "usuarios");
        }
    }
}
