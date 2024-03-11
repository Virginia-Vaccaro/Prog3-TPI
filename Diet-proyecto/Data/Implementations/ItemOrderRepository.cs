using Diet_proyecto.Data.Interfaces;
using Diet_proyecto.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Diet_proyecto.Data.Implementations
{
    public class ItemOrderRepository : Repository, IItemOrderRepository
    {
        public ItemOrderRepository(DietContext context) : base(context)
        {

        }

        public async Task DeleteItem(int id)
        {
            var itemToDelete = await _context.Items.FirstOrDefaultAsync(i => i.ItemOrderId == id);
            if (itemToDelete != null)
            {
                _context.Items.Remove(itemToDelete);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("El ítem a eliminar no se encontró.");
            }
        }
    }
}
