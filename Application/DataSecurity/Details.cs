using Application.Core;
using Application.UserManager;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.DataSecuritys
{
    public class Details
    {
        public class Query : IRequest<Result<DataSecurityDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<DataSecurityDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<DataSecurityDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await _context.DataSecuritys
                    .ProjectTo<DataSecurity>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);  

                //var rs = await UserFunctions.UserTypeList(_context, item.UserListID );
                DataSecurityDto res = new DataSecurityDto();
                 _mapper.Map(item, res);
                 //res.UserID = new 
                 var rs = await UserFunctions.UserTypeList(_context, item.UserListID );
                 foreach(UserType usr in rs.Value ){
                    if(usr.Type == "U"){
                        res.UserID.Add("U:" + usr.UserId);
                    }
                    else if(usr.Type == "G"){
                        res.UserID.Add("G:" + usr.UserId);
                    }
                   
                 }
                 //res.UserID = await UserFunctions.UserTypeList(_context, item.UserListID );

            
                return Result<DataSecurityDto>.Success(res);
            }
        }
    }
}
