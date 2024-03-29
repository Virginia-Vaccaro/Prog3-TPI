﻿using Diet_proyecto.Entities;
using Diet_proyecto.Models;

namespace Diet_proyecto.Mappers
{
    public class ProductMapper
    { 
        public static List<ProductDto> Map(IEnumerable<Product> products)
        {
            return products
                .Select(p => Map(p))
                .ToList();
        }

        public static ProductDto Map(Product product)
        {
            return new ProductDto 
            {
                Code = product.Code,
                Description = product.Description,
                Price = product.Price,
                Img = product.Img
            };
        }

        public static Product Map(ProductDto product)
        {
            return new Product
            {
                Code = product.Code,
                Description = product.Description,
                Price = product.Price,
                Img = product.Img
            };
        }

        public static CreateUpdateProductDto Map1(Product product)
        {
            return new CreateUpdateProductDto
            {
                Code = product.Code,
                Description = product.Description,
                Price = product.Price,
                Img = product.Img,
                StatusType = product.StatusType
            };
        }

        public static Product Map1(CreateUpdateProductDto product)
        {
            return new Product
            {
                Code = product.Code,
                Description = product.Description,
                Price = product.Price,
                Img = product.Img,
                StatusType = product.StatusType
            };
        }
    }
}
