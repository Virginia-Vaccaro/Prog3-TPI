using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Diet_proyecto.Entities
{
    public class ItemOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemOrderId { get; set; }

        public int Cantidad { get; set; }
        public int PriceCalc { get; set; } //precio del producto por la cantidad del mismo

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int? OrderId { get; set; }
        [ForeignKey("OderId")]
        public Order Order { get; set; }
    }
}
