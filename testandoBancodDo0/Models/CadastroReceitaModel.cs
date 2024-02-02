using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace testandoBancodDo0.Models
{
    public class CadastroReceitaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Ingredientes { get; set; }
        [Required]
        public string ModoPreparo { get; set; }
    }
}
