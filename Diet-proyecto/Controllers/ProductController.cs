using Diet_proyecto.Entities;
using Diet_proyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Diet_proyecto.Services.Interfaces;


namespace Diet_proyecto.Controllers
{
    [ApiController]
    [Route("api/product")]
    [Authorize(Roles ="Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            try
            {
                var products = _productService.GetAll();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            try
            {
                var product = _productService.Get(id);
                if (product == null)
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(CreateUpdateProductDto productDto)
        {
            try
            {
                var validation = ValidateProduct(productDto);
                if (!validation.IsValid)
                {
                    return BadRequest(validation.ErrorMessage);
                }

                var product = _productService.MapProductDtoToProduct(productDto);
                var prod = _productService.Add(product);

                return CreatedAtAction(nameof(GetProduct), new { id = prod.Id }, prod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut("{id}")]
        public ActionResult<ProductDto> UpdateProduct(int id, CreateUpdateProductDto product)
        {
            try
            {
                var validation = ValidateProduct(product);
                if (!validation.IsValid)
                {
                    return BadRequest(validation.ErrorMessage);
                }

                var prod = _productService.Get(id);
                if (prod == null)
                {
                    return NotFound();
                }

                prod.Code = product.Code;
                prod.Description = product.Description;
                prod.Price = product.Price;
                prod.Img = prod.Img;
                prod.LastModificationDate = DateTime.Now;
                prod.StatusType = product.StatusType;


                _productService.Update(prod);

                return Ok(prod);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

        [HttpDelete("{id}")]
        public ActionResult<ProductDto> DeleteProduct(int id)
        {
            try
            {
                //if (!id.HasValue)
                //{
                //    return BadRequest("No se ingresó ningún id");
                //}

                var product = _productService.Get(id);
                if (product == null)
                {
                    return NotFound();
                }

                _productService.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        private ValidationResultDto ValidateProduct(CreateUpdateProductDto product)
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
