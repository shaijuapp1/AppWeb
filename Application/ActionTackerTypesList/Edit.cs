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

namespace Application.ActionTackerTypesLists
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ActionTackerTypesListDto ActionTackerTypesList { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ActionTackerTypesList).SetValidator(new ActionTackerTypesListValidator());
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
                log.Source = "ProjectList";

                request.ActionTackerTypesList.ActionCreatedTime = DateTime.Now;
                var user = await _context.Users.FirstOrDefaultAsync( u => u.UserName == _userAccessor.GetUsername() );                     
                if (user != null){                    
                     log.ActionBy = user.Id; 
                }

                var item = await _context.ActionTackerTypesLists.FindAsync(request.ActionTackerTypesList.Id);
               
                if (item == null) return null; 
                _mapper.Map(request.ActionTackerTypesList, item);

                var result = await _context.SaveChangesAsync() > 0;
                if (!result) return Result<Unit>.Failure("Failed to update ActionTackerTypesList.");

                var rs = await UserFunctions.UpdateUser(_context, item.StakeHolders, request.ActionTackerTypesList.StakeHoldersList );
                               
                log.TaskID =  request.ActionTackerTypesList.Id;
                log.ActionTime = DateTime.Now;
                log.Action = request.ActionTackerTypesList.ActionTitle;
                log.Comment = request.ActionTackerTypesList.ActionComment;
                var logItem = _context.ActionTrackerAuditLogs.Add(log);
                var logResult = await _context.SaveChangesAsync() > 0;

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
