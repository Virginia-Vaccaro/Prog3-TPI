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

        public static ItemOrderDto Map(CreateItemOrderDto createItemOrderDto)
        {
            return new ItemOrderDto
            {
                Quantity = createItemOrderDto.Quantity,
                IdProduct = createItemOrderDto.IdProduct
            };
        }

        public static List<ItemOrderDto> MapList(List<CreateItemOrderDto> createItemOrderDtos)
        {
            List<ItemOrderDto> itemOrderDtos = new List<ItemOrderDto>();

            foreach (var createItemOrderDto in createItemOrderDtos)
            {
                var itemOrderDto = Map(createItemOrderDto);
                itemOrderDtos.Add(itemOrderDto);
            }

            return itemOrderDtos;
        }

    }
}
