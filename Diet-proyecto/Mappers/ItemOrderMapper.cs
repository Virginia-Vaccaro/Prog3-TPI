using Diet_proyecto.Entities;
using Diet_proyecto.Models;

namespace Diet_proyecto.Mappers
{
    public class ItemOrderMapper
    {
        public static ItemOrderDto Map(ItemOrder itemOrder)
        {
            return new ItemOrderDto
            {
                Quantity = itemOrder.Cantidad,
                PriceItem = itemOrder.PriceCalc,
                IdProduct = itemOrder.ProductId,
               
            };
        }

        public static ItemOrder Map(ItemOrderDto itemOrderDto)
        {
            return new ItemOrder
            {
                Cantidad = itemOrderDto.Quantity,
                PriceCalc = itemOrderDto.PriceItem,
                ProductId = itemOrderDto.IdProduct,
          
            };
        }
    }
}
