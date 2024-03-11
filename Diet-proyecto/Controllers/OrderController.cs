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
    [Authorize(Roles = "Client")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(List<CreateItemOrderDto> itemOrders, DeliveryStatus deliveryStatus, PaymentStatus paymentStatus)
        {
            try
            {
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

        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _orderService.GetOrderById(id);
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
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] UpdateOrderDto orderDto)
        {
            try
            {
                //if (orderDto == null || id != orderDto.Id)
                //{
                //    return BadRequest("No se puede actualizar la orden");
                //}
                var updatedOrder = await _orderService.UpdateOrder(id, orderDto);
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

        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var order = await _orderService.GetOrderById(id);
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
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersByUserName(string userName)
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
