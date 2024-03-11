using Diet_proyecto.Data;
using Diet_proyecto.Entities;
using Diet_proyecto.Models;
using Diet_proyecto.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Diet_proyecto.Services.Implementations
{
    public class AuthenticacionService : ICustomAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private object authRequestBody;

        public AuthenticacionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            if (string.IsNullOrEmpty(authRequestBody.UserName) || string.IsNullOrEmpty(authRequestBody.Password))
                return null;

            var user = _userRepository.GetUserByUsernameAndPassword(authRequestBody.UserName, authRequestBody.Password);
            if (user == null)
            {
                return null;
            }
            return user;
            
        } 
    }
}
