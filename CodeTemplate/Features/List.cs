using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.##Class##s
{
    public class List
    {
        public class Query : IRequest<Result<List<##Class##Dto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<##Class##Dto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<##Class##Dto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                
                var res = await _context.##Class##s
                    .ProjectTo<##Class##Dto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<##Class##Dto>>.Success(res);

            }
        }
    }
}