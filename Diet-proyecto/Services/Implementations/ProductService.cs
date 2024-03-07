using AutoMapper;
using Diet_proyecto.Entities;
using Diet_proyecto.Models;
using Diet_proyecto.Services.Interfaces;
using Diet_proyecto.Data.Interfaces;
using Diet_proyecto.Enum;


namespace Diet_proyecto.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IOrderService _orderService;

        public ProductService(IMapper mapper, IProductRepository productRepository, IOrderService ordenService)
        {
            this._mapper = mapper;
            this._productRepository = productRepository;
            this._orderService = ordenService;
        }
        public ProductDto CreateProduct(ProductDto newProduct, int ordenId, int userId)
        {
            var product = _mapper.Map<Product>(newProduct);

            product.CreationDate = DateTime.Now;
            product.StatusType = Status.Active;

            _productRepository.AddProduct(product);
            _productRepository.SaveChanges();

            return _mapper.Map<ProductDto>(product);
        }

        public Product? Get(int productId)
        {
            var product = _productRepository.GetProduct(productId);
            return _mapper.Map<Product>(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAllProducts();
        }

        public Product Add(Product product)
        {
            _productRepository.AddProduct(product);
            _productRepository.SaveChanges();
            return product;
        }

        public void Delete(int Id)
        {
            var product = _productRepository.GetProduct(Id);
            _productRepository.DeleteProduct(product);
            _productRepository.SaveChanges();
        }

        public Product Update(Product product)
        {
            _productRepository.UpdateProduct(product);
            _productRepository.SaveChanges();
            return product;
        }

        public Product MapProductDtoToProduct(CreateUpdateProductDto productDto)
        {
            return _mapper.Map<Product>(productDto);
        }
    }
}
