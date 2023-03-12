using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.DataSecuritys
{
    public class List
    {
        public class Query : IRequest<Result<List<DataSecurityDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<DataSecurityDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<DataSecurityDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                
                var res = await _context.DataSecuritys
                    .ProjectTo<DataSecurityDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<DataSecurityDto>>.Success(res);

            }
        }
    }
}
