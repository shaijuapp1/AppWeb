using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;

namespace Application.ToDos
{
    public class Test
    {
        public class Query : IRequest<List<ToDo>> { }

        public class Handler : IRequestHandler<Query, List<ToDo>>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<ToDo>> Handle(Query request, CancellationToken token)
            {
                return await _context.ToDos.ToListAsync();
            }
        }
    }
}