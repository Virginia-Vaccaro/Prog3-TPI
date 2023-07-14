namespace Diet_proyecto.Entities
{
    public class Client : User
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
