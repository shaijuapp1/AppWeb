using Domain;
using FluentValidation;

namespace Application.RoleMasters
{
    public class RoleMasterValidator : AbstractValidator<RoleMasterDto>
    {
        public RoleMasterValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
