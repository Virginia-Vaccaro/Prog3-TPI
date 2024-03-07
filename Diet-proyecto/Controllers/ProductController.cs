using Diet_proyecto.Entities;
using Diet_proyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Diet_proyecto.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace Diet_proyecto.Controllers
{
    [ApiController]
    [Route("api/product")]
    [Authorize(Roles ="Salesman")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<CreateUpdateProductDto> _productValidator;

        public ProductController(IProductService productService, IValidator<CreateUpdateProductDto> productValidator)
        {
            _productService = productService;
            _productValidator = productValidator;
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
                ValidationResult validationResult = _productValidator.Validate(productDto);

                if(!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
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
                ValidationResult validationResult = _productValidator.Validate(product);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
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

        
    }
}
