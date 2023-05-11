using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ActionTrackerAuditLogs
{
    public class List
    {
        public class Query : IRequest<Result<List<ActionTrackerAuditLogDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<ActionTrackerAuditLogDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<ActionTrackerAuditLogDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                try{
                    var res = await _context.ActionTrackerAuditLogs
                        .ProjectTo<ActionTrackerAuditLogDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

                        return Result<List<ActionTrackerAuditLogDto>>.Success(res);
                }
                catch(Exception ex){
                    
                    List<ActionTrackerAuditLogDto> r1 = new List<ActionTrackerAuditLogDto>();

                    ActionTrackerAuditLogDto r = new ActionTrackerAuditLogDto();
                    r.Comment = ex.Message;
                    r.Action = ex.StackTrace;
                    r1.Add(r);

                    return Result<List<ActionTrackerAuditLogDto>>.Success(r1);                 

                }
               

                

            }
        }
    }
}
