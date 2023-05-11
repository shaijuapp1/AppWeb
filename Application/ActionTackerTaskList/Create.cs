using System.Net;
using Application.Core;
using Application.Errors;
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
 
    public class Create
    {
        public class Command : IRequest<Result<int>>
        {
            public ActionTackerTaskListDto ActionTackerTaskList { get; set; }
        }
        
        public class Handler : IRequestHandler<Command, Result<int>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
            {
                _userAccessor = userAccessor;
                _context = context;
                _mapper = mapper;
            }

            public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ActionTackerTaskList).SetValidator(new ActionTackerTaskListValidator());
            }
        }

            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {        
                ActionTrackerAuditLog log = new ActionTrackerAuditLog();
                log.Source = "TaskList"; 

                var user = await _context.Users.FirstOrDefaultAsync( u => u.UserName == _userAccessor.GetUsername() );                     
                if (user != null){
                     log.ActionBy = user.Id; 
                }

                string RespId =  Guid.NewGuid().ToString();     
                var rs = await UserFunctions.UpdateUser(_context, RespId, request.ActionTackerTaskList.ResponsibilityList );

                string StkhId =  Guid.NewGuid().ToString();     
                var stkRs = await UserFunctions.UpdateUser(_context, StkhId, request.ActionTackerTaskList.StakeholderList );

                ActionTackerTaskList itm = new ActionTackerTaskList();
                
                _mapper.Map(request.ActionTackerTaskList, itm);
                itm.Stakeholder = StkhId;    
                itm.Responsibility = RespId;

                itm.ModifiedDate = DateTime.Now;
                var item = _context.ActionTackerTaskLists.Add(itm);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) {
                     throw new RestException(HttpStatusCode.OK, new { Error = $"No dows updated." });
                }               
                else{            
                    log.TaskID =  itm.Id;
                    log.ActionTime = DateTime.Now;
                    log.Action = request.ActionTackerTaskList.ActionTitle;
                    log.Comment = request.ActionTackerTaskList.ActionComment;

                    var logItem = _context.ActionTrackerAuditLogs.Add(log);
                    var logResult = await _context.SaveChangesAsync() > 0;
                }

                 return  Result<int>.Success( request.ActionTackerTaskList.Id);
            }
        }
    }
} 
