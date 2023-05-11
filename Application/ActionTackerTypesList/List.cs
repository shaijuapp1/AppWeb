using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ActionTackerTypesLists
{
    public class List
    {
        public class Query : IRequest<Result<List<ActionTackerTypesListDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<ActionTackerTypesListDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<ActionTackerTypesListDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                
                var res = await _context.ActionTackerTypesLists
                    .ProjectTo<ActionTackerTypesListDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<ActionTackerTypesListDto>>.Success(res);

            }
        }
    }
}
