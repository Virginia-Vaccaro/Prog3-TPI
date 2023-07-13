
//en el using traemos el proyecto  y el mEF
using Diet_proyecto;
using Diet_proyecto.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

namespace Diet_proyecto.DBContext
{
    public class OrdenesClientesContext : DbContext
    {
    //   //cargar todos los DbSet de todas las entities y luego armar el constructor

        public DbSet<Vendedor_> Vendedor { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<User> Users { get; set; }  
    //    public DbSet<Ordenes> Ordenes { get; set; }
       public DbSet<Product> Products { get; set; }

    //    // en el construc armar el Db options
    //    public OrdenesClientesContext(DbContextOptions<OrdenesClientesContext> options) : base(options)

    //    // hacer el On Model Creating que va cargandno data con el HasData
    //   protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Vendedor_>().HasData(
    //            new Vendedor_
    //            {
    //                Name = "Nicolas",
    //                LastName = "Casa",
    //                Password = "123",
    //                Email = "",
    //                Address = "",
    //                DNI = ,
    //                PhoneNumber = ,
    //                Id = 1
    //        });
    //    }
    }
}
