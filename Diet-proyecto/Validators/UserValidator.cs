using Diet_proyecto.Data;
using Diet_proyecto.Models;
using FluentValidation;

namespace Diet_proyecto.Validators
{
    public class UserValidator :AbstractValidator<CreateUpdateUserDto>
    {
        private readonly IUserRepository _userRepository;
        public UserValidator(IUserRepository userRepository) {

            _userRepository = userRepository;
        
            RuleFor(u => u.UserName).NotEmpty().Length(2,50)
                .Must((dto, userName) => BeUniqueUserName(userName, dto.ValidateUserNameUnique)).WithMessage("El nombre de usuario ya está en uso. Ingrese uno diferente.");
            RuleFor(u => u.Name).NotEmpty().Length(2,50);
            RuleFor(u => u.LastName).NotEmpty().Length(2,50);
            RuleFor(u => u.Email).EmailAddress().NotEmpty()
                .Must((dto, email) => BeUniqueEmail(email, dto.ValidateEmailUnique)).WithMessage("El email ya está registrado. Ingrese uno distinto.");
            RuleFor(u => u.Address).NotEmpty();
            RuleFor(u => u.PhoneNumber).Length(10)
                .WithMessage("El número de teléfono debe tener 10 dígitos (Ej: 3415888999");
            RuleFor(u => u.DNI).GreaterThan(9999999).WithMessage("El número de DNI debe tener al menos 8 dígitos");
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.UserType).NotEmpty()
                .Must(userType => userType == "Client" || userType == "Salesman" || userType == "Admin")
                .WithMessage("El tipo de usuario debe ser 'Client', 'Salesman' o 'Admin'.");
        }

        private bool BeUniqueEmail(string email , bool validateEmailUnique)
        {
            if (!validateEmailUnique)
                return true;

            return _userRepository.UniqueEmail(email);
        }

        private bool BeUniqueUserName(string userName, bool validateUserNameUnique)
        {
            if (!validateUserNameUnique)
                return true;

            return _userRepository.UniqueUserName(userName);
        }

    }
}
