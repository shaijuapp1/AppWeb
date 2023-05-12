using Application.Core;
using Application.UserManager;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

using System.Linq.Expressions;


namespace Application.ActionTackerTaskLists
{        
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T> ()  { return f => true;  }
        public static Expression<Func<T, bool>> False<T> () { return f => false; }
        
        public static Expression<Func<T, bool>> Or<T> (this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke (expr2, expr1.Parameters.Cast<Expression> ());
            return Expression.Lambda<Func<T, bool>>
                (Expression.OrElse (expr1.Body, invokedExpr), expr1.Parameters);
        }
        
        public static Expression<Func<T, bool>> And<T> (this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke (expr2, expr1.Parameters.Cast<Expression> ());
            return Expression.Lambda<Func<T, bool>>
                (Expression.AndAlso (expr1.Body, invokedExpr), expr1.Parameters);
        }
    }

    public class List
    {
        public class Query : IRequest<Result<List<ActionTackerTaskListDto>>> {
            public string status { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<ActionTackerTaskListDto>>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<ActionTackerTaskListDto>>> Handle(Query request, CancellationToken cancellationToken)
            {                
                var res = await _context.ActionTackerTaskLists
                    .ProjectTo<ActionTackerTaskListDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                foreach( ActionTackerTaskListDto r in res ){

                    var stk = await UserFunctions.UserTypeList(_context, r.Stakeholder );
                    foreach(UserType usr in stk.Value ){
                        if(usr.Type == "U"){
                            r.StakeholderList.Add("U:" + usr.UserId);
                        }
                        else if(usr.Type == "G"){
                            r.StakeholderList.Add("G:" + usr.UserId);
                        }                    
                    }

                    var rs = await UserFunctions.UserTypeList(_context, r.Responsibility );
                    foreach(UserType usr in rs.Value ){
                        if(usr.Type == "U"){
                            r.ResponsibilityList.Add("U:" + usr.UserId);
                        }
                        else if(usr.Type == "G"){
                            r.ResponsibilityList.Add("G:" + usr.UserId);
                        }   
                    }
                }
                // var predicate = PredicateBuilder.True <ActionTackerTaskList> ();
                // string[] keywords = {"Not Started", "In Progress", "Complected", "Complected"};
                // foreach (string keyword in keywords)
                //     predicate = predicate.Or (p => p.Description.Contains (keyword));
                // res.Where(predicate);

                return Result<List<ActionTackerTaskListDto>>.Success(res);

            }
        }
    }
}
