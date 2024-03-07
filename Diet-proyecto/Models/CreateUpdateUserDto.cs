namespace Diet_proyecto.Models
{
    public class CreateUpdateUserDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int DNI { get; set; }
        public string UserName { get; set; }
        public string UserType { get; set; }

        public string Password { get; set; }

        public  bool ValidateEmailUnique { get; set; }

        public bool ValidateUserNameUnique { get; set; }
    }
}
