using Diet_proyecto.Entities;
using Diet_proyecto.Models;

namespace Diet_proyecto.Data
{
    public interface IUserRepository : IRepository
    {
        User? GetUserByUsernameAndPassword(string username, string password);
        User? GetUserById(int? userId);

        IEnumerable<User> GetAllUsers();

        User CreateUser(User user); 

        User UpdateUser(int id, User user);
        void DeleteUser(int userId);

        bool UniqueEmail(string email);

        bool UniqueUserName(string userName);

    }
}