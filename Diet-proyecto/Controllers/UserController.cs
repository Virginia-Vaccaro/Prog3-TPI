
using Diet_proyecto.Entities;
using Diet_proyecto.Models;
using Diet_proyecto.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Diet_proyecto.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorize(Roles ="Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<CreateUpdateUserDto> _userValidator;

        public UserController(IUserService userService, IValidator<CreateUpdateUserDto> userValidator)
        {
            _userService = userService;
            _userValidator = userValidator;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            try
            {
                var users = _userService.GetAllUsers();

                return Ok(users);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    return BadRequest("No se ingresó ningún id");
                }

                var user = _userService.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public ActionResult<User> CreateUser(CreateUpdateUserDto createUpdateUserDto)
        {
            try
            {
                createUpdateUserDto.ValidateEmailUnique = true;
                createUpdateUserDto.ValidateUserNameUnique = true;

                ValidationResult validationResult = _userValidator.Validate(createUpdateUserDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var user = _userService.CreateUser(createUpdateUserDto);

                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            
        }

        [HttpPut("{id}")]
        public ActionResult<CreateUpdateUserDto> UpdateUser(int id, CreateUpdateUserDto createUpdateUserDto)
        {
            try
            {
                var existingUser = _userService.GetUserById(id);
                var isEmailChanged = existingUser?.Email != createUpdateUserDto.Email;
                var isUserNameChanged = existingUser?.UserName != createUpdateUserDto.UserName;

                createUpdateUserDto.ValidateEmailUnique = isEmailChanged;
                createUpdateUserDto.ValidateUserNameUnique = isUserNameChanged;

                ValidationResult validationResult = _userValidator.Validate(createUpdateUserDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var user = _userService.UpdateUser(id, createUpdateUserDto);
                if (user == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public ActionResult<UserDto> DeleteUser(int id)
        {
            try
            {
                //var userRole = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                //if (userRole != "Admin")
                //{
                //    return Forbid();
                //}

                _userService.DeleteUser(id);

                return NoContent();

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}



