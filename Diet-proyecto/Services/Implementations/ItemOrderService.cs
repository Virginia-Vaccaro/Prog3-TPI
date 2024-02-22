using Diet_proyecto.Data.Implementations;
using Diet_proyecto.Data.Interfaces;
using Diet_proyecto.Services.Interfaces;

namespace Diet_proyecto.Services.Implementations
{
    public class ItemOrderService : IItemOrderService
    {
        private readonly IItemOrderRepository _itemOrderRepository;

        public ItemOrderService(IItemOrderRepository itemOrderRepository)
        {
            _itemOrderRepository = itemOrderRepository;
        }
    }
}
