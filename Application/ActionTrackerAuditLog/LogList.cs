using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ActionTrackerAuditLogs
{ 
    public class LogList
    {
        public class Query : IRequest<Result<List<ActionTrackerAuditLogDto>>> 
        {
             public string type { get; set; }
             public int Id { get; set; }
         }

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
                
                var res = await _context.ActionTrackerAuditLogs     
                    .Where(c => c.TaskID == request.Id && c.Source == request.type )
                    .ProjectTo<ActionTrackerAuditLogDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();


                return Result<List<ActionTrackerAuditLogDto>>.Success(res);

            }
        }
    }
}
