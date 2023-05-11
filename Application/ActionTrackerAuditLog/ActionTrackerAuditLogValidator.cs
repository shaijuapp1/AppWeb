using Domain;
using FluentValidation;

namespace Application.ActionTrackerAuditLogs
{
    public class ActionTrackerAuditLogValidator : AbstractValidator<ActionTrackerAuditLog>
    {
        public ActionTrackerAuditLogValidator()
        {
            RuleFor(x => x.ActionBy).NotEmpty();
            RuleFor(x => x.ActionTime).NotEmpty();
        }
    }
}
