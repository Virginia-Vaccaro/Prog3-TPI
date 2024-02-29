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
            else if (authRequestBody.UserType == User.USER_TYPE_SALESMAN)
                return _context.Salesman.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);
            else if (authRequestBody.UserType == User.USER_TYPE_ADMIN)
                return _context.Admin.FirstOrDefault(p => p.UserName == authRequestBody.UserName && p.Password == authRequestBody.Password);

            return null;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public User? GetUserById(int? userId)
        {
            return _context.Users.Find(userId);
        }

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User UpdateUser(int userId, User user)
        {
            var existingUser = _context.Users.Find(userId);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.LastName = user.LastName;
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;
                existingUser.Address = user.Address;
                existingUser.PhoneNumber = user.PhoneNumber;

                _context.SaveChanges();
            }
            return existingUser;
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
