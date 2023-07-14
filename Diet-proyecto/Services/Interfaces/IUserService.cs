using Diet_proyecto.Models;

namespace Diet_proyecto.API.Services.Interfaces
{
    public interface IUserService
    {
        ICollection<ProductDto> GetProductByUser(int studentId);
    }
}