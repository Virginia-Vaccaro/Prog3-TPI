using Diet_proyecto.Entities;
using Diet_proyecto.DBContext;

namespace Diet_proyecto.Data
{
    public class SalesmanRepository : Repository, ISalesmanRepository
    {
        public SalesmanRepository(DietContext context) : base(context)
        {
        }

        public Salesman? GetById(int id) => _context.Salesman.Find(id);
    }
}
