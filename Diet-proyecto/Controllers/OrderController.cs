using Diet_proyecto.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diet_proyecto.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
    }
}
