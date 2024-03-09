using Diet_proyecto.Enum;
using Diet_proyecto.Models;


namespace Diet_proyecto.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrder(List<ItemOrderDto> itemOrder, int userId, DeliveryStatus deliveryStatus,  PaymentStatus paymentStatus );

        Task<OrderDto?> GetOrderById(int id);

        Task<OrderDto> UpdateOrder(int id, OrderDto orderDto);

        Task DeleteOrder(int id);

        Task<IEnumerable<OrderDto>> GetOrderByUser(string? userName);
    }
}
