using Diet_proyecto.Enum;

namespace Diet_proyecto.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public float ItemPrice { get; set; }
        public float TotalPrice { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}