using Diet_proyecto.Entities;
using Diet_proyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Diet_proyecto.DBContext;

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
                code = p.code,
                description = p.description,
                price = p.price,
                Quantity = p.Quantity,

            }).ToList();

            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = new ProductDto
            {
                code = product.code,
                description = product.description,
                price = product.price,
                Quantity = product.Quantity,
            };

            return Ok(productDto);
        }

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(ProductDto product)
        {
            if (product == null)
            {
                return BadRequest("El objeto product no puede ser nulo.");
            }

            if (string.IsNullOrEmpty(product.description))
            {
                return BadRequest("La descripción del producto es requerida.");
            }

            var prod = new Product
            {
                description = product.description,
                price = product.price,
                Quantity = product.Quantity,
            };

            _dbContext.Products.Add(prod);
            _dbContext.SaveChanges();

            product.code = prod.code;
            // Actualizar otras propiedades según tus necesidades

            return CreatedAtAction(nameof(GetProduct), new { id = prod.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductDto> UpdateProduct(int id, ProductDto product)
        {
            if (product == null)
            {
                return BadRequest("El objeto product no puede ser nulo.");
            }

            if (string.IsNullOrEmpty(product.description))
            {
                return BadRequest("La descripción del producto es requerida.");
            }

            var prod = _dbContext.Products.FirstOrDefault(p => p.Id == id);

            if (prod == null)
            {
                return NotFound();
            }

            prod.price = product.price;
            prod.Quantity = product.Quantity;

            _dbContext.SaveChanges();

            return Ok(product);

        }

        [HttpDelete("{id}")]
        public ActionResult<ProductDto> DeleteProduct(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
