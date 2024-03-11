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
            //if (order.Items ==  null || !order.Items.Any())
            //{
            //    throw new InvalidOperationException("ítems vacíos o nulos");
            //}

            return new OrderDto
                {
                    Id = order.Id,
                    ClientId = order.ClientId,
                    Items = order.Items.Select(ItemOrderMapper.Map).ToList(),
                    TotalPrice = order.TotalPrice,
                    PaymentStatus = order.PaymentStatus,
                    DeliveryStatus = order.DeliveryStatus,
                    DeliveryDateMessage = order.DeliveryDateMessage,
                };
            
            
        }

    }
}
