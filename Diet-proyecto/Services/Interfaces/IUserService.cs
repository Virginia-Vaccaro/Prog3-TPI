using Diet_proyecto.Entities;
using Diet_proyecto.Models;

namespace Diet_proyecto.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAllUsers();
        UserDto GetUserById(int? id);

        User CreateUser(CreateUpdateUserDto createUpdateUserDto);

        CreateUpdateUserDto UpdateUser(int id, CreateUpdateUserDto createUpdateUserDto);

        void DeleteUser(int id);
        //ICollection<ProductDto> GetProductByUser(int studentId);
    }
}