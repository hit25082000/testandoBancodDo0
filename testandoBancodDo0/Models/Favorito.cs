using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testandoBancodDo0.Models
{
    public class Favorito
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        public required string UsuarioId { get; set; }        

        public virtual ICollection<Receita> Receitas { get; set; }
    }
}
