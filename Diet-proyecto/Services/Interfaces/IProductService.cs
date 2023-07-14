namespace Diet_proyecto.Models
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
        Product Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
