using Domain;
using FluentValidation;

namespace Application.RoleMasters
{
    public class RoleMasterValidator : AbstractValidator<RoleMaster>
    {
        public RoleMasterValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
