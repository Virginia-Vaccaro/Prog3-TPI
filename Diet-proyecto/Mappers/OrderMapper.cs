using Diet_proyecto.Entities;
using Diet_proyecto.Models;

namespace Diet_proyecto.Mappers
{
    public class OrderMapper
    {
        public static List<OrderDto> Map(IEnumerable<Order> orders)
        {
            return orders
                .Select(p => Map(p))
                .ToList();
        }

        public static OrderDto Map(Order order)
        {
            var item = order.Items.FirstOrDefault();

            return new OrderDto
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ProductDescription = item.Product.Description,
                Quantity = item.Cantidad,
                ItemPrice = item.PriceCalc,
                TotalPrice = order.TotalPrice,
                PaymentStatus = order.PaymentStatus,
            };
        }
    }
}
