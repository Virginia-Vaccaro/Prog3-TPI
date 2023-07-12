using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diet_proyecto.Entities
{

    public class Ordenes
    {
        [Key]

        public int id { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente  ClienteOrden { get; set; }

    }
}
