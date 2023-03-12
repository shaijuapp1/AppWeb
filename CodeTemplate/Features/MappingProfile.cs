using Domain;
using FluentValidation;

namespace Application.##Class##s
{
    public class ##Class##Validator : AbstractValidator<##Class##>
    {
        public ##Class##Validator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}