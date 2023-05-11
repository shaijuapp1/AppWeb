using Domain;
using FluentValidation;

namespace Application.ActionTackerTaskLists
{
    public class ActionTackerTaskListValidator : AbstractValidator<ActionTackerTaskListDto>
    {
        public ActionTackerTaskListValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
