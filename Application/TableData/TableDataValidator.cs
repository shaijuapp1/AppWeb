using Domain;
using FluentValidation;

namespace Application.TableFields
{
    public class TableDataValidator : AbstractValidator<TableField>
    {
        public TableDataValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
