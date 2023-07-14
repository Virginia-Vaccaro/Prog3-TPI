using Diet_proyecto.Entities;
using Diet_proyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Diet_proyecto.DBContext;
using Diet_proyecto.Mappers;

namespace Diet_proyecto.Controllers
{
    [ApiController]
    [Route("api/product")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly DietContext _dbContext;

        public ProductController(DietContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            var products = _dbContext.Products.ToList();
            var productDtos = ProductMapper.Map(products);

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

            var productDto = ProductMapper.Map(product);

            return Ok(productDto);
        }

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(ProductDto product)
        {
            var validation = ValidateProduct(product);
            if (!validation.IsValid)
            {
                return BadRequest(validation.ErrorMessage);
            }

            var prod = ProductMapper.Map(product);
            prod.CreationDate = DateTime.Now;

            _dbContext.Products.Add(prod);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(GetProduct), new { id = prod.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult<ProductDto> UpdateProduct(int id, ProductDto product)
        {
            var validation = ValidateProduct(product);
            if (!validation.IsValid)
            {
                return BadRequest(validation.ErrorMessage);
            }

            var prod = _dbContext.Products.FirstOrDefault(p => p.Id == id);
            if (prod == null)
            {
                return NotFound();
            }

            prod.Code = product.Code;
            prod.Description = product.Description;
            prod.Price = product.Price;
            prod.Img = prod.Img;
            prod.LastModificationDate = DateTime.Now;

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

        private ValidationResultDto ValidateProduct(ProductDto product)
        {
            var errores = new List<string>();

            if (product == null)
            {
                errores.Add("Debe especificar los datos del producto.");
            }
            else
            {
                if (string.IsNullOrEmpty(product.Code))
                {
                    errores.Add("El código del producto es requerido.");
                }

                if (string.IsNullOrEmpty(product.Description))
                {
                    errores.Add("La descripción del producto es requerida.");
                }

                if (product.Price < 0)
                {
                    errores.Add("El precio debe ser igual o mayor a 0.");
                }
            }

            return new ValidationResultDto { ErrorMessages = errores };
        }
    }
}
