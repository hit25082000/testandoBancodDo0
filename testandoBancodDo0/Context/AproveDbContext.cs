using Microsoft.EntityFrameworkCore;
using testandoBancodDo0.Models;

namespace testandoBancodDo0.Context
{
    public class AproveDbContext : DbContext
    {
        public AproveDbContext(DbContextOptions<AproveDbContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Favorito>()
                .HasMany(favorito => favorito.Receitas)
                .WithMany(receita => receita.Favoritos);                

            builder.Entity<Receita>()
                .HasMany(receita => receita.Favoritos)
                .WithMany(favoritos => favoritos.Receitas);            
        }

        public DbSet<UsuarioModel> usuarios { get; set; }
        public DbSet<CadastroReceitaModel> cad_receitas { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<SugestaoReceitaModel> tab_sugestaoRec { get; set; }
        public DbSet<IngredientesModel> tab_ingredientes { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
    }
}
