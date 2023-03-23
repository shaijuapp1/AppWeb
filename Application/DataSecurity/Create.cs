using System.Net;
using Application.Core;
using Application.Errors;
using Application.Interfaces;
using Application.UserManager;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.DataSecuritys
{
 
    public class Create
    {
        public class Command : IRequest<Result<int>>
        {
            public DataSecurityDto DataSecurity { get; set; }
        }
        
        public class Handler : IRequestHandler<Command, Result<int>>
        {
            private readonly DataContext _context;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IUserAccessor userAccessor, IMapper mapper)
            {
                _userAccessor = userAccessor;
                _context = context;
                _mapper = mapper;
            }

            public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DataSecurity).SetValidator(new DataSecurityValidator());
            }
        }

            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {       
                string UserGrpId =  Guid.NewGuid().ToString();     
                var rs = await UserFunctions.UpdateUser(_context, UserGrpId, request.DataSecurity.UserID );

                DataSecurity it = new DataSecurity();
                it.TableId = request.DataSecurity.TableId;
                it.AccessType = request.DataSecurity.AccessType;
                it.Access = request.DataSecurity.Access;
                
                it.FiledId = request.DataSecurity.TableId;
                //it.StatusId = request.DataSecurity.TableId;
                it.UserListID = UserGrpId;

                 var item = _context.DataSecuritys.Add(it);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) {
                     throw new RestException(HttpStatusCode.OK, new { Error = $"No dows updated." });
                }

               

                return  Result<int>.Success( request.DataSecurity.Id);
            }
        }
    }
}
