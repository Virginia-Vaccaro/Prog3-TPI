using Diet_proyecto.Models;
using FluentValidation;

namespace Diet_proyecto.Validators
{
    public class ProductValidator : AbstractValidator<CreateUpdateProductDto>
    {
        public ProductValidator() 
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.Description).NotEmpty().Length(2,40);
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.StatusType).IsInEnum();
            RuleFor(p => p.Img).NotEmpty().Must(BeAValidUrl).WithMessage("La URL de imagen no es válida.");
        }

        private bool BeAValidUrl(string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
