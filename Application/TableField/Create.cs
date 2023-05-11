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

namespace Application.TableFields
{
 
    public class Create
    {
        public class Command : IRequest<Result<int>>
        {
            public TableField TableField { get; set; }
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
                RuleFor(x => x.TableField).SetValidator(new TableFieldValidator());
            }
        }

            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {               
                var r = 
                    await GetNextField(request.TableField.TableId, request.TableField.FiledType);

                request.TableField.FideldName = r.Value;

                 var item = _context.TableFields.Add(request.TableField);

                var result = await _context.SaveChangesAsync() > 0;

                if (!result) {
                     throw new RestException(HttpStatusCode.OK, new { Error = $"No dows updated." });
                }

                 return  Result<int>.Success( request.TableField.Id);
            }

             public async Task<Result<string>> GetNextField(int tableID, string filedType){
                string nextField = string.Empty;

                int maxLen = 0;
                string prfx = string.Empty;

                switch(filedType){
                    case "Text":
                         maxLen = 20;   
                         prfx = "Txt";
                         break;   
                    case "Date":
                         maxLen = 10;   
                         prfx = "Date";
                         break;    
                    case "Number":
                         maxLen = 10;   
                         prfx = "Num";
                         break;   
                    case "User":
                         maxLen = 10;   
                         prfx = "User";
                         break;  
                    default:  
                        maxLen = 20;   
                         prfx = "Txt"; 
                         break;         
                }
                
                //query 
                var fields = await _context.TableFields     
                    .Where(c => c.TableId == tableID && c.FiledType == filedType )
                    .ToListAsync();

                // if(filedType == "Text"){                 
                // }

                for(int i=1;i<=maxLen;i++){
                    string flName = prfx + i.ToString();

                    bool find = false;

                    for(int j=0;j<fields.Count;j++){
                        if( fields[j].FideldName == flName ){
                            find = true;
                            break;
                        }
                    }                        
                    if(!find){
                        nextField = flName;
                        break;
                    }
                }

                return  Result<string>.Success( nextField);

            }
        }
    
        
    }
}
