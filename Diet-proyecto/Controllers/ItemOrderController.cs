using Diet_proyecto.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diet_proyecto.Controllers
{
    public class ItemOrderController : ControllerBase
    {
        private readonly IItemOrderService _itemOrderService;

        public ItemOrderController(IItemOrderService itemOrderService)
        {
            _itemOrderService = itemOrderService;
        }
        
    }
}
