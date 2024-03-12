using Diet_proyecto.Entities;
using Diet_proyecto.Enum;
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
    
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder(List<CreateItemOrderDto> itemOrders, DeliveryStatus deliveryStatus, PaymentStatus paymentStatus)
        {
            try
            {
                var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (userRole != "Client")
                {
                    return Forbid();
                }

                if (itemOrders == null || !itemOrders.Any())
                {
                    return BadRequest("No se puede crear una orden vacía.");
                }
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var newOrder = await _orderService.CreateOrder(itemOrders, int.Parse(userId), deliveryStatus, paymentStatus);

                return Ok(newOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                var order = await _orderService.GetOrderById(id, int.Parse(userId), userRole);
                if (order == null)
                {
                    return NotFound();
                }
                return Ok(order);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDto orderDto)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var updatedOrder = await _orderService.UpdateOrder(id, orderDto, userId);

                if (updatedOrder == null)
                {
                    return NotFound("No se encontró la orden");
                }
                return Ok(updatedOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

                var order = await _orderService.GetOrderById(id, int.Parse(userId), userRole);
                if (order == null)
                {
                    return NotFound();
                }

                 await _orderService.DeleteOrder(id);

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("user/{userName}/order")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByUserName(string userName)
        {
            try
            {
                var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                if (userRole == "Client" || userRole == "Salesman")
                {
                    var orders = await _orderService.GetOrderByUser(userName);
                    if (orders.Any())
                    {
                        return Ok(orders);
                    }
                    else
                    {
                        return NotFound("El usuario no tiene órdenes creadas.");
                    }
                    
                }
                return Forbid();



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
