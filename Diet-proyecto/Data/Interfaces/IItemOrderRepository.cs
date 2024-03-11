namespace Diet_proyecto.Data.Interfaces
{
    public interface IItemOrderRepository : IRepository
    {
        Task DeleteItem(int id);
    }
}
