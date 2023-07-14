using Diet_proyecto.Entities;

namespace Diet_proyecto.Data
{
    public interface ISalesmanRepository
    {
        Salesman? GetById(int id);
    }
}