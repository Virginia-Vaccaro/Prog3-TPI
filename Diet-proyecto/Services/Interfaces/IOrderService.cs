using Diet_proyecto.Models;


namespace Diet_proyecto.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrder(List<ItemOrderDto> itemOrder, int userId);

        Task<OrderDto> GetOrderById(int id);

        Task<OrderDto> UpdateOrder(int id, OrderDto orderDto);
    }
}
