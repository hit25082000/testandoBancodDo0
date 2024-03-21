using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace testandoBancodDo0.Models
{
    public class SugestaoReceitaModel
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ModoPreparo { get; set; }
        public string Ingredientes { get; set; }

        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }
        public virtual UsuarioModel Usuario { get; set; }
    }
}
