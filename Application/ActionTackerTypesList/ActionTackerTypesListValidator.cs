using Domain;
using FluentValidation;

namespace Application.ActionTackerTypesLists
{
    public class ActionTackerTypesListValidator : AbstractValidator<ActionTackerTypesListDto>
    {
        public ActionTackerTypesListValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
