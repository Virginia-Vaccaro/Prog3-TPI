using Diet_proyecto.Models;

namespace Diet_proyecto.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int id);

        UserDto CreateUser(UserDto userDto);

        UserDto UpdateUser(int id, UserDto userDto);

        void DeleteUser(int id);
        //ICollection<ProductDto> GetProductByUser(int studentId);
    }
}