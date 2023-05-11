using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ActionTrackerAuditLogs
{
    public class Details
    {
        public class Query : IRequest<Result<ActionTrackerAuditLogDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ActionTrackerAuditLogDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<ActionTrackerAuditLogDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await _context.ActionTrackerAuditLogs
                    .ProjectTo<ActionTrackerAuditLogDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);                
                return Result<ActionTrackerAuditLogDto>.Success(item);
            }
        }
    }
}
