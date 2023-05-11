using Application.Core;
using Application.UserManager;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ActionTackerTaskLists
{
    public class Details
    {
        public class Query : IRequest<Result<ActionTackerTaskListDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ActionTackerTaskListDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<ActionTackerTaskListDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await _context.ActionTackerTaskLists
                    .ProjectTo<ActionTackerTaskListDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);  
 
                var stk = await UserFunctions.UserTypeList(_context, item.Stakeholder );
                foreach(UserType usr in stk.Value ){
                    if(usr.Type == "U"){
                        item.StakeholderList.Add("U:" + usr.UserId);
                    }
                    else if(usr.Type == "G"){
                        item.StakeholderList.Add("G:" + usr.UserId);
                    }                    
                 }

                var rs = await UserFunctions.UserTypeList(_context, item.Responsibility );
                foreach(UserType usr in rs.Value ){
                    if(usr.Type == "U"){
                        item.ResponsibilityList.Add("U:" + usr.UserId);
                    }
                    else if(usr.Type == "G"){
                        item.ResponsibilityList.Add("G:" + usr.UserId);
                    }                    
                 }

                return Result<ActionTackerTaskListDto>.Success(item);
            }
        }
    }
}
