using Domain;
using FluentValidation;

namespace Application.AppConfigs
{
    public class AppConfigValidator : AbstractValidator<AppConfig>
    {
        public AppConfigValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
