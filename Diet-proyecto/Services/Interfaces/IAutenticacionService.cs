using Diet_proyecto.Entities;
using Diet_proyecto.Models;

namespace Diet_proyecto.Services.Interfaces
{
    public interface ICustomAuthenticationService
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
    }
}