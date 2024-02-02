using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testandoBancodDo0.Models
{
    public class ReceitaModel
    {
        [Key]
        public int idReceita { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ModoPreparo { get; set; }

        [ForeignKey("Ingredientes")]
        public int idIngredientes { get; set; }
        public IngredientesModel Ingredientes { get; set; }

        [ForeignKey("Sugestao")]
        public int idSugestao { get; set; }
        public SugestaoReceitaModel SugestaoReceita { get; set; }
        


    }
}
