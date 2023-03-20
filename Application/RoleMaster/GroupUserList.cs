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
        public class Query : IRequest<Result<List<RoleMasterDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<RoleMasterDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<RoleMasterDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                 //IList<AppUser> usr = await _userManager.GetUsersInRoleAsync(request.RoleName);    

                // List<IdentityRole> roles = await  _context.AspNetRoles.ToListAsync();

                // try{
                //     return _mapper.Map<List<IdentityRole>, List<RoleMasterDto>>(roles);
                // }catch(Exception ex){
                //       throw new RestException(HttpStatusCode.OK, new { Error = $" {ex.Message}. {ex.InnerException.Message}." });
                // }

                
                var res = await _context.AspNetRoles
                    .ProjectTo<RoleMasterDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return Result<List<RoleMasterDto>>.Success(res);

            }
        }
    }
}
