using Diet_proyecto.Entities;
using Diet_proyecto.Models;

namespace Diet_proyecto.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Add(Product product);
        Product Update(Product product);
        void Delete(int id);

        public Product MapProductDtoToProduct(CreateUpdateProductDto productDto);
    }
}
