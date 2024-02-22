using Diet_proyecto.Data.Interfaces;
using Diet_proyecto.DBContext;

namespace Diet_proyecto.Data.Implementations
{
    public class OrderRepository : Repository, IOrderRepository
    {
        public OrderRepository(DietContext context) : base(context)
        {
        }
    }
}
