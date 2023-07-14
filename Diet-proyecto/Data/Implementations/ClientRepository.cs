using Diet_proyecto.Entities;
using Diet_proyecto.DBContext;

namespace Diet_proyecto.Data
{
    public class ClientRepository : Repository, IClientRepository
    {
        public ClientRepository(DietContext context) : base(context)
        {

        }

        public Client? GetById(int id) => _context.Clients.Find(id);
    }
}
