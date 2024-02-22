using Diet_proyecto.Entities;

namespace Diet_proyecto.Data.Interfaces
{
    public interface IProductRepository : IRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(Product product);
        Product? GetProduct(int productId);

        void UpdateProduct(Product product);

        IEnumerable<Product> GetAllProducts();
    }
}
