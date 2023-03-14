using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.UserManagers
{
    public class Details
    {
        public class Query : IRequest<Result<UserManagerDto>>
        {
            public string Username { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<UserManagerDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<UserManagerDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await _context.Users
                    .ProjectTo<UserManagerDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Username == request.Username);                
                return Result<UserManagerDto>.Success(item);
            }
        }
    }
}
