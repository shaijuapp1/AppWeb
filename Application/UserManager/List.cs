using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.UserManagers
{
    public class List
    {
        public class Query : IRequest<Result<List<UserManagerDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<UserManagerDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<UserManagerDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                
                var res = await _context.Users
                    .ProjectTo<UserManagerDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<UserManagerDto>>.Success(res);

            }
        }
    }
}
