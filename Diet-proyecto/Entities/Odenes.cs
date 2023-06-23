using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet_proyecto.Entities
{

    public class Odenes
    {
        [Key]

        public int id { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente  ClienteOrden { get; set; }

        public ICollection<Product> Product { get; set; } = new List<Product>();
    }
}
