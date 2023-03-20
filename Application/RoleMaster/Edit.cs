using System.Net;
using Application.Core;
using Application.Errors;
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
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public RoleMasterDto RoleMaster { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.RoleMaster).SetValidator(new RoleMasterValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            private RoleManager<IdentityRole> _roleManager;

            public Handler(DataContext context, IMapper mapper, RoleManager<IdentityRole> roleMgr)
            {
                _mapper = mapper;
                _context = context;
                _roleManager = roleMgr;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {        
                var role = await _roleManager.FindByIdAsync(request.RoleMaster.Id);
                if(role == null){
                    throw new RestException(HttpStatusCode.OK, new { Error = $"Ront not found." });
                }
                role.Name = request.RoleMaster.Name;

                try{
                    await _roleManager.UpdateAsync(role);
                    //var res =  _mapper.Map <IdentityRole, RoleMasterDto>(role);   
                    return Result<Unit>.Success(Unit.Value);             
                } 
                catch(Exception ex){
                     throw new RestException(HttpStatusCode.OK, new { Error = $"Problem saving changes. {ex.Message}. {ex.InnerException.Message}." });
                } 



                // var item = await _context.RoleMasters.FindAsync(request.RoleMaster.Id);
               
                // if (item == null) return null;

                // _mapper.Map(request.RoleMaster, item);
                
                // var result = await _context.SaveChangesAsync() > 0;

                // if (!result) return Result<Unit>.Failure("Failed to update RoleMaster.");

                // return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
