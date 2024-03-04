using Diet_proyecto.Entities;
using Diet_proyecto.Models;
using Diet_proyecto.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace Diet_proyecto.Controllers
{
    [ApiController]
    [Route("api/order")]
    [Authorize(Roles = "Client")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(List<ItemOrderDto> itemOrders)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var newOrder = await _orderService.CreateOrder(itemOrders, int.Parse(userId));

                return Ok(newOrder);
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.InnerException.Message);
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut]
        //public async Task<IActionResult> UpdateOrder(int id, [FromBody] OrderDto orderDto)
        //{
        //    try
        //    {
        //        var updatedOrder = await _orderService.UpdateOrder(id, orderDto);
        //        return Ok(updatedOrder);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        
    }
}
