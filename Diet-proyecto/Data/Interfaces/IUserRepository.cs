using Diet_proyecto.Entities;
using Diet_proyecto.Models;

namespace Diet_proyecto.Data
{
    public interface IUserRepository : IRepository
    {
        User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
        User? GetUserById(int userId);
    }
}