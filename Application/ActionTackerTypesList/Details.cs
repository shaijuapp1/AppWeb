using Application.Core;
using Application.UserManager;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.ActionTackerTypesLists
{
    public class Details
    {
        public class Query : IRequest<Result<ActionTackerTypesListDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ActionTackerTypesListDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<ActionTackerTypesListDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await _context.ActionTackerTypesLists
                    .ProjectTo<ActionTackerTypesListDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);   

                var rs = await UserFunctions.UserTypeList(_context, item.StakeHolders );
                foreach(UserType usr in rs.Value ){
                    if(usr.Type == "U"){
                        item.StakeHoldersList.Add("U:" + usr.UserId);
                    }
                    else if(usr.Type == "G"){
                        item.StakeHoldersList.Add("G:" + usr.UserId);
                    }                    
                 }
                              
                return Result<ActionTackerTypesListDto>.Success(item);
            }
        }
    }
}
