using Microsoft.EntityFrameworkCore;
using testandoBancodDo0.Models;

namespace testandoBancodDo0.Context
{
    public class AproveDbContext:DbContext
    {
        public AproveDbContext(DbContextOptions<AproveDbContext> options) : base(options) 
        {
            
        }

        public DbSet<UsuarioModel> usuarios { get; set; }
        public DbSet<CadastroReceitaModel> cad_receitas { get; set; }
        public DbSet<ReceitaModel> tab_receitas { get; set; }
        public DbSet<SugestaoReceitaModel> tab_sugestaoRec { get; set; }
        public DbSet<IngredientesModel> tab_ingredientes { get; set; }
        

    }
}
