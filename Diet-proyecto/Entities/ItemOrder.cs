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
        public float PriceCalc { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int? OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public ItemOrder()
        {
        }

        public ItemOrder(int cantidad , float precioProducto) 
        { 
            Cantidad = cantidad;
            PriceCalc = Cantidad * precioProducto;
        }
    }
}
