using Diet_proyecto.DBContext;

namespace Diet_proyecto.Data
{
    public class Repository : IRepository
    {
        internal readonly DietContext _context;

        public Repository(DietContext context)
        {
            this._context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
