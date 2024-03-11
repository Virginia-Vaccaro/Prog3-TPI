using Diet_proyecto.Enum;

namespace Diet_proyecto.Models
{
    public class UpdateOrderDto
    {
        public List<CreateItemOrderDto>? Items { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public DeliveryStatus DeliveryStatus { get; set; }
    }
}
