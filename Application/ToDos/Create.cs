using System.Net;
using Application.Core;
using Application.Errors;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ToDos
{
 
    public class Create
    {
        public class Command : IRequest<Result<int>>
        {
            public ToDo ToDo { get; set; }
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
                RuleFor(x => x.ToDo).SetValidator(new ToDoValidator());
            }
        }

            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => 
                    x.UserName == _userAccessor.GetUsername());

                var assignedTo = new ToDoAssignedTo
                {
                    AppUser = user,
                    ToDo = request.ToDo,
                    IsCreatedBy = true
                };

                request.ToDo.AssignedTo.Add(assignedTo);

                 var todo = _context.ToDos.Add(request.ToDo);

                var result = await _context.SaveChangesAsync() > 0;

                // if (!result) {
                //     return Result<Unit>.Failure("Failed to create activity");
                // }
                // else{
                //     return  request.ToDo; 
                // }

                // return Result<Unit>.Success(Unit.Value);

                if (!result) {
                     throw new RestException(HttpStatusCode.OK, new { Error = $"No dows updated." });
                }

                 return  Result<int>.Success( request.ToDo.Id);
            }
        }
    }
}