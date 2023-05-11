using System.Net;
using System.Security.Claims;
using Application.Core;
using Application.Errors;
using Application.Interfaces;
using Application.UserManager;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ActionTackerTypesLists
{
 
    public class Create
    {
        public class Command : IRequest<Result<int>>
        {
            public ActionTackerTypesListDto ActionTackerTypesList { get; set; }
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
                    RuleFor(x => x.ActionTackerTypesList).SetValidator(new ActionTackerTypesListValidator());
                }
            }

            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {           
                ActionTrackerAuditLog log = new ActionTrackerAuditLog();
                log.Source = "ProjectList";
                                 
                request.ActionTackerTypesList.ActionCreatedTime = DateTime.Now;
                var user = await _context.Users.FirstOrDefaultAsync( u => u.UserName == _userAccessor.GetUsername() );                     
                if (user != null){
                     request.ActionTackerTypesList.ActionCreaedBy = user.Id;
                     log.ActionBy = user.Id;
                }

                string UserGrpId =  Guid.NewGuid().ToString();     
                var rs = await UserFunctions.UpdateUser(_context, UserGrpId, request.ActionTackerTypesList.StakeHoldersList );

                ActionTackerTypesList itm = new ActionTackerTypesList();
                _mapper.Map(request.ActionTackerTypesList, itm);
                itm.StakeHolders = UserGrpId;

                var item = _context.ActionTackerTypesLists.Add(itm);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) {
                     throw new RestException(HttpStatusCode.OK, new { Error = $"No dows updated." });
                }
                else{            
                    log.TaskID =  itm.Id;
                    log.ActionTime = DateTime.Now;
                    log.Action = request.ActionTackerTypesList.ActionTitle;
                    log.Comment = request.ActionTackerTypesList.ActionComment;

                    var logItem = _context.ActionTrackerAuditLogs.Add(log);
                    var logResult = await _context.SaveChangesAsync() > 0;
                }

                 return  Result<int>.Success( request.ActionTackerTypesList.Id);
            }
        }
    }
}
