using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Diet_proyecto.Entities
{
    public class User
    {
        public const string USER_TYPE_CLIENT = "Client";
        public const string USER_TYPE_SALESMAN = "Salesman";

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
        [Required]
        public string UserName { get; set; }
        public string UserType { get; set; }
    }
}
