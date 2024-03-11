using Diet_proyecto.Entities;
using Diet_proyecto.Models;
using Diet_proyecto.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Diet_proyecto.Data
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(DietContext context) : base(context)
        {
        }

        public User? GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
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

        public bool UniqueEmail(string email)
        {
            return _context.Users.All(x => x.Email != email);
        }

        public bool UniqueUserName(string userName)
        {
            return _context.Users.All(u => u.UserName != userName);
        }

        public async Task<User?> GetUserByUserName(string? userName)
        {

            return await _context.Users.FirstOrDefaultAsync(u => u.UserName != null && u.UserName.ToLower() == userName.ToLower());

        }
    }
}
