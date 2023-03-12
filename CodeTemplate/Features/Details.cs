using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.##Class##s
{
    public class Details
    {
        public class Query : IRequest<Result<##Class##Dto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<##Class##Dto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<##Class##Dto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await _context.##Class##s
                    .ProjectTo<##Class##Dto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);                
                return Result<##Class##Dto>.Success(item);
            }
        }
    }
}