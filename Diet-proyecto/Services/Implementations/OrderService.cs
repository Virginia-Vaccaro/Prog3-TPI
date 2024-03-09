﻿using Diet_proyecto.Data.Interfaces;
using Diet_proyecto.Entities;
using Diet_proyecto.Enum;
using Diet_proyecto.Models;
using Diet_proyecto.Services.Interfaces;
using Diet_proyecto.Mappers;
using Diet_proyecto.Data;

namespace Diet_proyecto.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }




        public async Task<OrderDto> CreateOrder(List<ItemOrderDto> itemOrders, int userId, DeliveryStatus deliveryStatus, PaymentStatus paymentStatus)
        {

            if (itemOrders == null || itemOrders.Count == 0)
            {
                throw new Exception("No se seleccionaron productos. La orden no fue generada.");
            }

            foreach (var item in itemOrders)
            {
                var product =  _productRepository.GetProduct(item.IdProduct);
                if (product == null || product.StatusType != Status.Active)
                {
                    throw new Exception("Uno o más productos no están disponibles para la venta.");
                }
            }

            
            DateTime currentDate = DateTime.Today;
            DayOfWeek currentDayOfWeek = currentDate.DayOfWeek;
            DateTime deliveryDate;
            if (currentDayOfWeek == DayOfWeek.Saturday)
            {
                deliveryDate = currentDate.AddDays(2);
            }
            else
            {
                deliveryDate = currentDate.AddDays(1);
            }

            string deliveryDateMessage = deliveryDate.ToString("dd/MM/yyyy");
            string deliveryMessage = $"Tu pedido estará listo para el día {deliveryDateMessage} de 12 a 18 hs.";

            var order = new Order
            {
                ClientId = userId,
                OrderStatus = Enum.OrderStatus.InProgress,
                PaymentStatus = PaymentStatus.Unpaid,
                DeliveryStatus = deliveryStatus,
                DeliveryDateMessage = deliveryMessage
        };

            foreach (var item in itemOrders)
            {
                if (item.Quantity <= 0)
                {
                    throw new Exception("La cantidad de productos debe ser mayor que cero.");
                }

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





        public async Task<OrderDto?> GetOrderById(int id)
        {
            var order = await _orderRepository.GetOrderById(id);
            if (order == null)
            {
                return null;
            }
            return OrderMapper.Map(order);
        }





        public async Task<OrderDto> UpdateOrder(int id,  OrderDto orderDto)
        {
            var existingOrder = await _orderRepository.GetOrderById(id);
            if(existingOrder == null)
            {
                throw new Exception("No se encontró la orden.");
            }

            if (orderDto.Items == null || orderDto.Items.All(item => item.Quantity == 0))
            {
                await _orderRepository.DeleteOrder(id); 
                throw new Exception("La orden se eliminó con éxito."); 
            }

            if (orderDto.Items != null && orderDto.Items.Any())
            {
               
                foreach (var itemDto in orderDto.Items)
                {
                    var existingItem =  existingOrder.Items.FirstOrDefault(item => item.ProductId == itemDto.IdProduct);
                    if (existingItem != null)
                    {
                        var product = _productRepository.GetProduct(existingItem.ProductId);
                        if (product == null)
                        {
                            throw new Exception("Producto no encontrado");
                        }
                        existingItem.Cantidad = itemDto.Quantity;
                        existingItem.PriceCalc = product.Price * existingItem.Cantidad;
                    }
                    else
                    {
                        var product = _productRepository.GetProduct(itemDto.IdProduct);
                        if (product == null)
                        {
                            throw new Exception("Producto no encontrado");
                        }
                        
                        var newItem = new ItemOrder
                        {
                            ProductId = itemDto.IdProduct,
                            Cantidad = itemDto.Quantity,
                            PriceCalc = itemDto.Quantity * product.Price
                        };
                        existingOrder.Items.Add(newItem);
                    }
                }
            }
          
            existingOrder.PaymentStatus = orderDto.PaymentStatus;
            existingOrder.DeliveryStatus = orderDto.DeliveryStatus;
            
            existingOrder.TotalPrice = existingOrder.Items.Sum(item => item.PriceCalc);

            var updatedOrder = await _orderRepository.UpdateOrder(existingOrder);

            return OrderMapper.Map(updatedOrder);
        }





        public async Task DeleteOrder(int id)
        {
            var order =  await _orderRepository.GetOrderById(id);
            _orderRepository.DeleteOrder(order.Id);
            _orderRepository.SaveChanges();
        }






        public async Task<IEnumerable<OrderDto>> GetOrderByUser(string? userName)
        {

            var user = await _userRepository.GetUserByUserName(userName);
            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }
            else
            {
                var orders = await _orderRepository.GetOrdersByUser(user.Id);
                if (orders.Any())
                {
                    var orderDtos = orders.Select(OrderMapper.Map);
                    return orderDtos;
                }
                else
                {
                    throw new Exception("El usuario no tiene órdenes creadas.");
                }
            }           
        }
    }
}
