﻿using Diet_proyecto.Entities;

namespace Diet_proyecto.Data.Interfaces
{
    public interface IOrderRepository : IRepository
    {
        Task<Order> CreateOrder(Order order);

        Task<Order?> GetOrderById(int id);
        Task<Order> UpdateOrder(Order order);

        Task<IEnumerable<Order>> GetOrdersByUser(int idUser);

        Task DeleteOrder(int id);
    }
}
