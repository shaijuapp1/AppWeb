using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.RoleMasters
{
    public class Details
    {
        public class Query : IRequest<Result<RoleMasterDto>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<RoleMasterDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<RoleMasterDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await _context.AspNetRoles
                    .ProjectTo<RoleMasterDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);                
                return Result<RoleMasterDto>.Success(item);
            }
        }
    }
}
