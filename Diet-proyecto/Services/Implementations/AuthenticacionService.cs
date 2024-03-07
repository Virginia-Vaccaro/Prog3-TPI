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

            if (authRequestBody.UserType == User.USER_TYPE_CLIENT)
                return _userRepository.GetUserByUsernameAndPassword(authRequestBody.UserName , authRequestBody.Password);
            else if (authRequestBody.UserType == User.USER_TYPE_SALESMAN)
                return _userRepository.GetUserByUsernameAndPassword(authRequestBody.UserName , authRequestBody.Password);
            else if (authRequestBody.UserType == User.USER_TYPE_ADMIN)
                return _userRepository.GetUserByUsernameAndPassword(authRequestBody.UserName , authRequestBody.Password);

            return null;
        } 
    }
}
