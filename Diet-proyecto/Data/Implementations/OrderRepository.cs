using Diet_proyecto.Data.Interfaces;
using Diet_proyecto.DBContext;
using Diet_proyecto.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diet_proyecto.Data.Implementations
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(DietContext context) : base(context)
        {
            
        }

        public async Task<Order> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> GetOrderById(int id)
        {
            return await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
