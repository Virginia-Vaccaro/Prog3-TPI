using Diet_proyecto.Enum;
using Diet_proyecto.Models;


namespace Diet_proyecto.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrder(List<CreateItemOrderDto> itemOrder, int userId, DeliveryStatus deliveryStatus,  PaymentStatus paymentStatus );

        Task<OrderDto?> GetOrderById(int id, int idUser, string userRole);

        Task<OrderDto> UpdateOrder(int id, UpdateOrderDto orderDto, string userId);

        Task DeleteOrder(int id);

        Task<IEnumerable<OrderDto>> GetOrderByUser(string? userName);
    }
}
