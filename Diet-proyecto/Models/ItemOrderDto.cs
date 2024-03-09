using Diet_proyecto.Entities;

namespace Diet_proyecto.Models
{
    public class ItemOrderDto
    {
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
        public float PriceItem { get; set; }

    }
}
