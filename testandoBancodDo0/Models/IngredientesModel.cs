using System.ComponentModel.DataAnnotations;

namespace testandoBancodDo0.Models
{
    public class IngredientesModel
    {
        [Key]
        public int idIngredientes { get; set; }
        public string Nome { get; set; }
        public string Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
    }
}
