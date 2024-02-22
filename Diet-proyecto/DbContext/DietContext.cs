//en el using traemos el proyecto  y el mEF
using Diet_proyecto;
using Diet_proyecto.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diet_proyecto.DBContext
{
    public class DietContext : DbContext
    { 
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Salesman> Salesman { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ItemOrder> Items { get; set; }
        

        // en el construc armar el Db options
        public DietContext(DbContextOptions<DietContext> options) : base(options)
        {
        }

        // hacer el On Model Creating que va cargandno data con el HasData
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Name = "Virginia",
                    LastName = "Vaccaro",
                    Password = "123vir",
                    Email = "vir.vaccaro@gmail.com",
                    Address = "calle 123",
                    DNI = 35131301,
                    PhoneNumber = 11223344,
                    UserName = "Vir",
                    Id = 1
                });

            modelBuilder.Entity<Salesman>().HasData(
                new Salesman
                {
                    Name = "Facundo",
                    LastName = "Bargut",
                    Password = "123facu",
                    Email = "facu@gmail.com",
                    Address = "calle 456",
                    DNI = 11333222,
                    PhoneNumber = 11223355,
                    UserName = "Facu",
                    Id = 3
                });

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Name = "Lucy",
                    LastName = "Ramon",
                    Password = "123LR",
                    Email = "lr@gmail.com",
                    Address = "calle 456",
                    DNI = 11333444,
                    PhoneNumber = 11223366,
                    UserName = "Lura",
                    Id = 2
                });

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Client)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.ClientId);

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Client)
                .OnDelete(DeleteBehavior.Cascade); //elimina las orders asociadas a un Client si el mismo es eliminado
                //.ToTable("ClientOrder");  ??????

            modelBuilder.Entity<ItemOrder>()
                .HasOne(i => i.Product)
                .WithMany()
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<ItemOrder>()
                .HasOne(o => o.Order)
                .WithMany()
                .HasForeignKey(i => i.OrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}