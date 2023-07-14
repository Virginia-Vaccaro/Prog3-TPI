using System.Collections.Generic;

namespace Diet_proyecto.Models
{
    public interface IProductService
    {
        IEnumerable<ProductDto> GetAll();
        ProductDto Get(string code);
        ProductDto Add(ProductDto product);
        void Update(ProductDto product);
        void Delete(string code);
    }
}
//MODIFICAR MÉTODOS SEGÚN NECESIDADES