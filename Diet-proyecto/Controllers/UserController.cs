using Diet_proyecto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diet_proyecto.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            // Obtener todos los usuarios
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(int id)
        {
            // Obtener un usuario por su ID
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser(UserDto user)
        {
            // Crear un nuevo usuario
        }

        [HttpPut("{id}")]
        public ActionResult<UserDto> UpdateUser(int id, UserDto user)
        {
            // Actualizar un usuario existente
        }

        [HttpDelete("{id}")]
        public ActionResult<UserDto> DeleteUser(int id)
        {
            //Eliminar un usuario por su ID
        }
    }
}
