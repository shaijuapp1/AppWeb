using Domain;
using FluentValidation;

namespace Application.DataSecuritys
{
    public class DataSecurityValidator : AbstractValidator<DataSecurity>
    {
        public DataSecurityValidator()
        {
            RuleFor(x => x.TableId).NotEmpty();
        }
    }
}
