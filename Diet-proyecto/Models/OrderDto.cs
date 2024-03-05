using Diet_proyecto.Enum;

namespace Diet_proyecto.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public List<ItemOrderDto> Items { get; set; }
        public float TotalPrice { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}