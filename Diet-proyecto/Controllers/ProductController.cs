using Diet_proyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diet_proyecto.Controllers
{
    [ApiController]
    [Route("api/product")]
    [Authorize]
    public class ProductController
    {
        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> GetProduct()
        {
            // Obtener todos 
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetProduct(int id)
        {
            // Obtener por su ID
        }

        [HttpPost]
        public ActionResult<ProductDto> CreateProduct(UserDto user)
        {
            // Crear nuevo
        }

        [HttpPut("{id}")]
        public ActionResult<ProductDto> UpdateProduct(int id, UserDto user)
        {
            // Actualizar  existente
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductDto> DeleteProduct(int id)
        {
            //Eliminar por su ID
        }
    }
}
