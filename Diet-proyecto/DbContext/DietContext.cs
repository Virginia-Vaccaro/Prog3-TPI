//en el using traemos el proyecto  y el mEF
using Diet_proyecto;
using Diet_proyecto.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diet_proyecto.DBContext
{
    public class DietContext : DbContext
    {
        //cargar todos los DbSet de todas las entities y luego armar el constructor
        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        // en el construc armar el Db options
        public DietContext(DbContextOptions<DietContext> options) : base(options)
        {
        }

        // hacer el On Model Creating que va cargandno data con el HasData
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<Salesman>().HasData(
                new Salesman
                {
                    Name = "Nicolas",
                    LastName = "Casa",
                    Password = "123",
                    Email = "mail@mail.com",
                    Address = "calle a 123",
                    DNI = 11222333,
                    PhoneNumber = 11223344,
                    Id = 1
                });
        }
    }
}