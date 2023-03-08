using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ToDos
{
    public class List
    {
        public class Query : IRequest<Result<List<ToDoDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<ToDoDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<ToDoDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                
                var res = await _context.ToDos
                    .ProjectTo<ToDoDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<ToDoDto>>.Success(res);

            }
        }
    }
}