using Diet_proyecto.Entities;
using Diet_proyecto.Models;
using Diet_proyecto.DBContext;

namespace Diet_proyecto.Data
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(DietContext context) : base(context)
        {
        }

        public User? ValidateUser(AuthenticationRequestBody authRequestBody)
        {
            if (authRequestBody.UserType == User.USER_TYPE_CLIENT)
                return _context.Clients.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);

            return _context.Salesmen.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
        }

        public User? GetUserById(int userId)
        {
            return _context.Users.Find(userId);
        }
    }
}
