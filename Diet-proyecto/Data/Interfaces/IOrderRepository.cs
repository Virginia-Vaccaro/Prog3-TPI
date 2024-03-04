using Diet_proyecto.Entities;

namespace Diet_proyecto.Data.Interfaces
{
    public interface IOrderRepository : IRepository
    {
        Task<Order> CreateOrder(Order order);
        //Task<Order> UpdateOrder(Order order);
    }
}
