using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.DataSecuritys
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public DataSecurity DataSecurity { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.DataSecurity).SetValidator(new DataSecurityValidator());
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
                var item = await _context.DataSecuritys.FindAsync(request.DataSecurity.Id);
               
                if (item == null) return null;

                _mapper.Map(request.DataSecurity, item);
                
                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update DataSecurity.");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
