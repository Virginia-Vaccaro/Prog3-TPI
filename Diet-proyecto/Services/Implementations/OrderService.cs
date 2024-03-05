using Diet_proyecto.Data.Interfaces;
using Diet_proyecto.Entities;
using Diet_proyecto.Enum;
using Diet_proyecto.Models;
using Diet_proyecto.Services.Interfaces;
using Diet_proyecto.Mappers;

namespace Diet_proyecto.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<OrderDto> CreateOrder(List<ItemOrderDto> itemOrders, int userId)
        {
            var order = new Order
            {
                ClientId = userId,
                StatusType = Enum.Status.Active,
                PaymentStatus = PaymentStatus.Unpaid,

            };

            foreach (var item in itemOrders)
            {

                var product = _productRepository.GetProduct(item.IdProduct);
                if (product == null)
                {
                    throw new Exception("Producto no encontrado");
                }

                var itemOrder = new ItemOrder
                {
                    ProductId = product.Id,
                    Cantidad = item.Quantity,
                    PriceCalc = product.Price * item.Quantity
                };

                order.TotalPrice += itemOrder.PriceCalc;

                order.Items.Add(itemOrder);
            }

            var createdOrder = await _orderRepository.CreateOrder(order);

            return OrderMapper.Map(createdOrder);
        }



        public async Task<OrderDto> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderById(id);

            return OrderMapper.Map(order);
        }

        public async Task<OrderDto> UpdateOrder(int id,  OrderDto orderDto)
        {
            var existingOrder = await _orderRepository.GetOrderById(id);
            if(existingOrder == null)
            {
                throw new Exception("No se encontró la orden.");
            }

            existingOrder.PaymentStatus = orderDto.PaymentStatus;
            existingOrder.Items.FirstOrDefault().Cantidad = orderDto.Quantity;

            var updatedOrder = await _orderRepository.UpdateOrder(existingOrder);

            return OrderMapper.Map(updatedOrder);
        }


    }
}
