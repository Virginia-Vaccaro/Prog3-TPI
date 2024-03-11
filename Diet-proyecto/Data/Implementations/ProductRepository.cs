using Diet_proyecto.Data.Interfaces;
using Diet_proyecto.DBContext;
using Diet_proyecto.Entities;

namespace Diet_proyecto.Data.Implementations
{
    public class ProductRepository: Repository, IProductRepository 
    {
        public ProductRepository(DietContext context) : base(context)
        {

        }
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void DeleteProduct(Product product) 
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        public Product? GetProduct(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.Id == productId);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public IEnumerable<Product> GetAllProducts() { 
        
            return _context.Products;
        }


    }
}
