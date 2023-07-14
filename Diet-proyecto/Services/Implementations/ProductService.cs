using AutoMapper;
using Diet_proyecto.API.Data;
using Diet_proyecto.API.Entities;
using Diet_proyecto.API.Models.Responses;
using Diet_proyecto.API.Services.Interfaces;

namespace Diet_proyecto.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IOrdenService _ordenService;

        public ProductService(IMapper mapper, IProductRepository productRepository, IOrdenService ordenService)
        {
            this._mapper = mapper;
            this._productRepository = productRepository;
            this._ordenService = ordenService;
        }
        public ProductDto CreateProduct(ProductForCreationDto newProduct, int ordenId, int userId)
        {
            var product = _mapper.Map<Product>(newProduct);

            product.OrdenId = ordenId;
            product.CreatorId = userId;

            _productRepository.AddProduct(product);
            _productRepository.SaveChanges();

            _ordenService.ChangeOrdenStatus(ordenId);

            return _mapper.Map<ProductDto>(product);
        }

        public ProductDto? GetProduct(int productId)
        {
            var product = _productRepository.GetProduct(productId);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
