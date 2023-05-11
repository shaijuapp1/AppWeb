using Application.Core;
using Application.Interfaces;
using Application.UserManager;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ActionTackerTaskLists
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ActionTackerTaskListDto ActionTackerTaskList { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ActionTackerTaskList).SetValidator(new ActionTackerTaskListValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;

            public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
            {
                _userAccessor = userAccessor;
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {           
                ActionTrackerAuditLog log = new ActionTrackerAuditLog();
                log.Source = "TaskList";

                var user = await _context.Users.FirstOrDefaultAsync( u => u.UserName == _userAccessor.GetUsername() );                     
                if (user != null){
                     log.ActionBy = user.Id; 
                }

                var item = await _context.ActionTackerTaskLists.FindAsync(request.ActionTackerTaskList.Id);
                

                if (item == null) return null;
                _mapper.Map(request.ActionTackerTaskList, item);
                item.ModifiedDate = DateTime.Now;
                
                var result = await _context.SaveChangesAsync() > 0;                
                if (!result) return Result<Unit>.Failure("Failed to update ActionTackerTaskList.");

                var rs = await UserFunctions.UpdateUser(_context, item.Responsibility, request.ActionTackerTaskList.ResponsibilityList );
                var stkRs = await UserFunctions.UpdateUser(_context, item.Stakeholder, request.ActionTackerTaskList.StakeholderList );

                log.TaskID =  item.Id;
                log.ActionTime = DateTime.Now;
                log.Action = request.ActionTackerTaskList.ActionTitle;
                log.Comment = request.ActionTackerTaskList.ActionComment;

                var logItem = _context.ActionTrackerAuditLogs.Add(log);
                var logResult = await _context.SaveChangesAsync() > 0;

                return Result<Unit>.Success(Unit.Value);  
            }
        }
    }
}
