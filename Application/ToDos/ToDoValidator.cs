using Domain;
using FluentValidation;

namespace Application.ToDos
{
    public class ToDoValidator : AbstractValidator<ToDo>
    {
        public ToDoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}