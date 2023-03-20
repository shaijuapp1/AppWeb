using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.RoleMasters
{
    public class GroupUserList
    {
        public class Query : IRequest<Result<List<GroupUserDTO>>> { 
            public string RoleName { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<GroupUserDTO>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private readonly UserManager<AppUser> _userManager;

            public Handler(DataContext context, IMapper mapper, UserManager<AppUser> userManager)
            {
                _mapper = mapper;
                _context = context;
                _userManager = userManager;
            }

            public async Task<Result<List<GroupUserDTO>>> Handle(Query request, CancellationToken cancellationToken)
            {
                IList<AppUser> usr = await _userManager.GetUsersInRoleAsync(request.RoleName);
                var res = _mapper.Map<IList<AppUser>, List<GroupUserDTO>>(usr);
                return Result<List<GroupUserDTO>>.Success(res);
               
            }
        }
    }
}
