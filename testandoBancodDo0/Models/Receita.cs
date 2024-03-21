using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testandoBancodDo0.Models
{
    public class Receita
    {      
        public Receita()
        {
            Id = new Random().Next();
        }

        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ModoPreparo { get; set; }

        [ForeignKey("Ingredientes")]
        public int IdIngredientes { get; set; }
        public virtual IngredientesModel? Ingredientes { get; set; }

        [ForeignKey("SugestaoReceita")]
        public int IdSugestao { get; set; }
        public virtual SugestaoReceitaModel? SugestaoReceita { get; set; }
        
        public virtual ICollection<Favorito>? Favoritos { get; set; }
    }
}
