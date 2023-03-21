// namespace Application.RoleMaster
// {
//     public class AddUserToRole
//     {
        
//     }
// }

using System.Net;
using Application.Core;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.RoleMasters
{
 
    public class AddUserToRole
    {
        public class Command : IRequest<Result<bool>>
        {
            public string UserName { get; set; }
            public string RoleName { get; set; }
        }
        
        public class Handler : IRequestHandler<Command, Result<bool>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;
            private RoleManager<IdentityRole> _roleManager;
            private readonly UserManager<AppUser> _userManager;

            public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper, RoleManager<IdentityRole> roleMgr, UserManager<AppUser> userManager)
            {
                _userAccessor = userAccessor;
                _context = context;
                _mapper = mapper;
                _roleManager = roleMgr;
                _userManager = userManager;
            }

            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                {
                    RuleFor(x => x.UserName).NotEmpty();
				    RuleFor(x => x.RoleName).NotEmpty();
                }
            }

            public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
            {     
                if (!await _roleManager.RoleExistsAsync( request.RoleName)) {
                     throw new RestException(HttpStatusCode.OK, new { Error = $"Role {request.RoleName} not found." });
                }

                var user = await _context.Users.FirstOrDefaultAsync( u => u.UserName == request.UserName  );                     
                if (user == null){
                     throw new RestException(HttpStatusCode.OK, new { Error = $"User {request.UserName} not found" });
                }

                var v = await _userManager.AddToRoleAsync(user, request.RoleName );
                if(v.Succeeded){
                    return Result<bool>.Success(true);
                }
                else{
                     return Result<bool>.Success(false);
                }                
            }
        }
    }
}

