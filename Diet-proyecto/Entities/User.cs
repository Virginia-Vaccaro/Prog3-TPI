using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Diet_proyecto.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int DNI { get; set; }
        public int PhoneNumber { get; set; }


        public ICollection<Cliente> Cliente { get; set; } = new List<Cliente>();    
        public ICollection<Vendedor_> Vendedor { get; set; } = new List<Vendedor_>();
        public ICollection<Product> Product { get; set; } = new List<Product>();    
    }
}
