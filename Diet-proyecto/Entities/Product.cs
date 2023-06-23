using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Diet_proyecto.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public string img { get; set; }
        public int Quantity { get; set; }
    }
}
