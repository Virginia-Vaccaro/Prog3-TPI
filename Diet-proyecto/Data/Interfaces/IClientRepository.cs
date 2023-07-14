using Diet_proyecto.Entities;

namespace Diet_proyecto.Data
{
    public interface IClientRepository
    {
        Client? GetById(int id);
    }
}