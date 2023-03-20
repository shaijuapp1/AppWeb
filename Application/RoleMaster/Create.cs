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
 
    public class Create
    {
        public class Command : IRequest<Result<RoleMasterDto>>
        {
            public RoleMasterDto RoleMaster { get; set; }
        }
        
        public class Handler : IRequestHandler<Command, Result<RoleMasterDto>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;
            private RoleManager<IdentityRole> _roleManager;

            public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper, RoleManager<IdentityRole> roleMgr)
            {
                _userAccessor = userAccessor;
                _context = context;
                _mapper = mapper;
                _roleManager = roleMgr;
            }

            public class CommandValidator : AbstractValidator<Command>
            {
                public CommandValidator()
                {
                    RuleFor(x => x.RoleMaster).SetValidator(new RoleMasterValidator());
                }
            }

            public async Task<Result<RoleMasterDto>> Handle(Command request, CancellationToken cancellationToken)
            {     
                if (!await _roleManager.RoleExistsAsync( request.RoleMaster.Name)) {
                    var role = new IdentityRole();    
                    role.Name = request.RoleMaster.Name;    
                    await _roleManager.CreateAsync(role);   
                    var toReturn = _mapper.Map <IdentityRole, RoleMasterDto>(role);
                    return Result<RoleMasterDto>.Success(toReturn);
                }
                else{
                     throw new RestException(HttpStatusCode.OK, new { Error = $"Role {request.RoleMaster.Name} alreday exists." });
                }  

            }
        }
    }
}
