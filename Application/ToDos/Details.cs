using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ToDos
{
    public class Details
    {
        public class Query : IRequest<Result<ToDo>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ToDo>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<ToDo>> Handle(Query request, CancellationToken cancellationToken)
            {
                // var todo = await _context.ToDos
                //     .ProjectTo<ToDoDto>(_mapper.ConfigurationProvider)
                //     .FirstOrDefaultAsync(x => x.Id == request.Id);

                var todo = await _context.ToDos.FindAsync(request.Id);

                return Result<ToDo>.Success(todo);
            }
        }
    }
}