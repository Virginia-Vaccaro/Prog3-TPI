using Diet_proyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diet_proyecto.Controllers
{
    [ApiController]
    [Route("api/product")]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly OrdenesClientesContext _dbContext;

        public ProductController(OrdenesClientesContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
       public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            var products = _dbContext.Products.ToList();

            var productDtos = products.Select(p => new ProductDto
            {
                code = p.Id,
                description = p.Name,

            }).ToList();

            return Ok(productDtos);
        }

    //    [HttpGet("{id}")]
    //    //public ActionResult<ProductDto> GetProduct(int id)
    //    //{
    //    //    // Obtener por su ID
    //    //}

    //    //[HttpPost]
    //    //public ActionResult<ProductDto> CreateProduct(ProductDto product)
    //    //{
    //    //    // Crear nuevo
    //    //}

    //    //[HttpPut("{id}")]
    //    //public ActionResult<ProductDto> UpdateProduct(int id, ProductDto product)
    //    //{
    //    //    // Actualizar  existente
    //    //}

    //    //[HttpDelete("{id}")]
    //    //public ActionResult<ProductDto> DeleteProduct(int id)
    //    //{
    //    //    //Eliminar por su ID
    //    //}
    }
}
