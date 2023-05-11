using Application.AppConfigTypes;
using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppConfigs
{
    public class ConfigList
    {
        public class Query : IRequest<Result<List<AppConfigDto>>> 
        {
             public string Title { get; set; }
         }

        // public class Query : IRequest<Result<AppConfigDto>>
        // {
        //     public int Id { get; set; }
        // }

        public class Handler : IRequestHandler<Query, Result<List<AppConfigDto>>>        
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<AppConfigDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var CconfigTypes = await _context.AppConfigTypes
                    .ProjectTo<AppConfigTypeDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Title == request.Title); 

                var res = await _context.AppConfigs     
                    .Where(c => c.ConfigTypeId == CconfigTypes.Id )
                    .ProjectTo<AppConfigDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

                // var res = await _context.AppConfigs
                //     .ProjectTo<AppConfigDto>(_mapper.ConfigurationProvider)
                //     .ToListAsync(cancellationToken);

                return Result<List<AppConfigDto>>.Success(res);

            }
        }
    }
}
