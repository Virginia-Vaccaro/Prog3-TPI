using Diet_proyecto.Data.Interfaces;
using Diet_proyecto.DBContext;

namespace Diet_proyecto.Data.Implementations
{
    public class ItemOrderRepository : Repository, IItemOrderRepository
    {
        public ItemOrderRepository(DietContext context) : base(context)
        {
        }
    }
}
