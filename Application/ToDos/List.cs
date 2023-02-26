using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ToDos
{
    public class List
    {
        public class Query : IRequest<Result<List<ToDo>>> { }

        public class Handler : IRequestHandler<Query, Result<List<ToDo>>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Result<List<ToDo>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<ToDo>>.Success(await _context.ToDos.ToListAsync());
            }
        }
    }
}