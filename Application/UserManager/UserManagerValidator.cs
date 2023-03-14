using Domain;
using FluentValidation;

namespace Application.UserManagers
{
    public class UserManagerValidator : AbstractValidator<AppUser>
    {
        public UserManagerValidator()
        {
            RuleFor(x => x.UserName).NotEmpty();
        }
    }
}
