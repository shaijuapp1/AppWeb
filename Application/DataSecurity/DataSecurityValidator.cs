using Domain;
using FluentValidation;

namespace Application.DataSecuritys
{
    public class DataSecurityValidator : AbstractValidator<DataSecurityDto>
    {
        public DataSecurityValidator()
        {
            RuleFor(x => x.TableId).NotEmpty();
            RuleFor(x => x.AccessType).NotEmpty();
            RuleFor(x => x.Access).NotEmpty();
        }
    }
}
