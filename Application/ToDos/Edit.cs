using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ToDos
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ToDo ToDo { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.ToDo).SetValidator(new ToDoValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {               
                var toDo = await _context.ToDos
                    .Include( t => t.AssignedTo )
                    .FirstOrDefaultAsync(x => x.Id == request.ToDo.Id); 
               
                if (toDo == null) return null;

                toDo.Title  = request.ToDo.Title ?? request.ToDo.Title;
                
                toDo.TragetDate  = request.ToDo.TragetDate;
                
                # region Add/Remove ToDoAssignedTo

                ICollection<ToDoAssignedTo> AssignedTo = new List<ToDoAssignedTo>(); 
                //Remove if not exists
                ICollection<ToDoAssignedTo> remList = new List<ToDoAssignedTo>();
                foreach( ToDoAssignedTo ass in  toDo.AssignedTo ){
                    bool remove = true;
                    foreach( ToDoAssignedTo toass in  request.ToDo.AssignedTo ){
                        if( ass.AppUserId == toass.AppUserId ){
                            remove = false;
                        }
                    }
                    if(remove){
                        remList.Add(ass);
                        
                    }                    
                }
                foreach( ToDoAssignedTo ass in  remList ){
                    toDo.AssignedTo.Remove(ass);
                }

                toDo = await _context.ToDos
                    .Include( t => t.AssignedTo )
                    .FirstOrDefaultAsync(x => x.Id == request.ToDo.Id); 

                
                //Add New items
                ICollection<ToDoAssignedTo> addList = new List<ToDoAssignedTo>();
                foreach( ToDoAssignedTo toass in  request.ToDo.AssignedTo ){
                     bool add = true;
                    foreach( ToDoAssignedTo ass in  toDo.AssignedTo ){
                          if( ass.AppUserId == toass.AppUserId ){
                            add = false;
                        }
                    }
                    if(add){
                        addList.Add(toass);                                  
                    }         
                }
                foreach( ToDoAssignedTo ass in  addList ){
                    toDo.AssignedTo.Add(ass);
                }

                # endregion  Add/Remove ToDoAssignedTo

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update AppConfigType = ");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}