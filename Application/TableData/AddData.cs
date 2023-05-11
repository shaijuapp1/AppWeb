// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace Application.TableData
// {
//     public class AddData
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
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Persistence;

namespace Application.TableData
{
 
    public class AddData
    {
        public class Command : IRequest<Result<int>>
        {
            public int TableId { get; set; }
            public string DataJson { get; set; }
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
            // public CommandValidator()
            // {
            //     RuleFor(x => x.TableId).SetValidator(new TableFieldValidator());
            // }
        }

            public async Task<Result<int>> Handle(Command request, CancellationToken cancellationToken)
            {       
                // 1. Get field details from TableField
                // 2. Check colums are valid 
                // 3. Check Security
                // 3. Add data into  TableFieldData

                //JsonConvert
                List<TableDataJSField> dataList 
                    = JsonConvert.DeserializeObject<List<TableDataJSField>>(request.DataJson);
                foreach (TableDataJSField data in dataList)
                {
                    // if (data.List == ListName)
                    // {
                    //     updateItem[data.Title] = data.Value;
                    // }
                    // //res += data.Title + " - " + data.Value + ", ";
                }
                
                Domain.TableData item = new Domain.TableData();
                item.TableId = request.TableId;
                var res = _context.TableDatas.Add(item);
                var result = await _context.SaveChangesAsync() > 0;

                if (!result) {
                     throw new RestException(HttpStatusCode.OK, new { Error = $"No dows updated." });
                }

                return  Result<int>.Success(item.Id);
            }
        }
    }
}
