using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.##Class##s
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public ##Class## ##Class## { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.##Class##).SetValidator(new ##Class##Validator());
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
                var item = await _context.##Class##s.FindAsync(request.##Class##.Id);
               
                if (item == null) return null;

                _mapper.Map(request.##Class##, item);
                
                var result = await _context.SaveChangesAsync() > 0;

                if (!result) return Result<Unit>.Failure("Failed to update ##Class##.");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}