
using Diet_proyecto.Models;
using Diet_proyecto.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Diet_proyecto.Controllers
{
    [ApiController]
    [Route("api/users")]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            // 1A-Obtener todos los usuarios
            //var users = _context.Users.Select(u => new UserDto
            //{
            //    Name = u.Name,
            //    LastName = u.LastName,
            //    Password = u.Password,
            //    Email = u.Email,
            //    Address = u.Address,
            //    DNI = u.DNI,
            //    PhoneNumber = u.PhoneNumber
            //}).ToList();

            var users = _userService.GetAllUsers();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(int id)
        {
            // 1B-Obtener un usuario por su ID
            //var user = _context.Users.Find(id);
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            //var userDto = new UserDto
            //{
            //    Name = user.Name,
            //    LastName = user.LastName,
            //    Password = user.Password,
            //    Email = user.Email,
            //    Address = user.Address,
            //    DNI = user.DNI,
            //    PhoneNumber = user.PhoneNumber
            //};

            return Ok(user);
        }

        [HttpPost]
        public ActionResult<UserDto> CreateUser(UserDto userDto)
        {
            // 2- Crear un nuevo usuario
            //var user = new User
            //{
            //    Name = userDto.Name,
            //    LastName = userDto.LastName,
            //    Password = userDto.Password,
            //    Email = userDto.Email,
            //    Address = userDto.Address,
            //    DNI = userDto.DNI,
            //    PhoneNumber = userDto.PhoneNumber
            //};

            //_context.Users.Add(user);
            //_context.SaveChanges();

            var user = _userService.CreateUser(userDto);

            return CreatedAtAction(nameof(GetUser), userDto);
        }

        [HttpPut("{id}")]
        public ActionResult<UserDto> UpdateUser(int id, UserDto userDto)
        {
            // 3-Actualizar un usuario existente
            //var user = _context.Users.Find(id);

            var user = _userService.UpdateUser(id , userDto);
            if (user == null)
            {
                return NotFound();
            }

            //user.Name = userDto.Name;
            //user.LastName = userDto.LastName;
            //user.Password = userDto.Password;
            //user.Email = userDto.Email;
            //user.Address = userDto.Address;
            //user.DNI = userDto.DNI;
            //user.PhoneNumber = userDto.PhoneNumber;

            //_context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<UserDto> DeleteUser(int id)
        {
            // 4-Eliminar un usuario por su ID
            //var user = _context.Users.Find(id);

            //if (user == null)
            //{
            //    return NotFound();
            //}

            //_context.Users.Remove(user);
            //_context.SaveChanges();

            _userService.DeleteUser(id);

            return NoContent();
        }
    }
}



