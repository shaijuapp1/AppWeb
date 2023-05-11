using System.Net;
using Application.Core;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ActionTrackerAuditLogs
{
 
    public class Create
    {
        public class Command : IRequest<Result<int>>
        {
            public ActionTrackerAuditLog ActionTrackerAuditLog { get; set; }
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
                    RuleFor(x => x.ActionTrackerAuditLog).SetValidator(new ActionTrackerAuditLogValidator());
                }
            }

            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {               
                 var item = _context.ActionTrackerAuditLogs.Add(request.ActionTrackerAuditLog);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) {
                     throw new RestException(HttpStatusCode.OK, new { Error = $"No dows updated." });
                }

                 return  Result<int>.Success( request.ActionTrackerAuditLog.Id);
            }
        }
    }
}
