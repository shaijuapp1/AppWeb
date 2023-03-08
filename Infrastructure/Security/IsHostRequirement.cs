using System.Security.Claims;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastructure.Security
{
    public class IsHostRequirement : IAuthorizationRequirement
    {
    }

    public class IsHostRequirementHandler : AuthorizationHandler<IsHostRequirement>
    {
        private readonly DataContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserAccessor _userAccessor;
        private readonly UserManager<AppUser> _userManager;

        public IsHostRequirementHandler(DataContext dbContext, IHttpContextAccessor httpContextAccessor, IUserAccessor userAccessor, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _userAccessor = userAccessor;
            _userManager = userManager;
            
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, IsHostRequirement requirement)
        {
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            AppUser user = await _userManager.FindByIdAsync(userId); // .FindByNameAsync(_userAccessor.GetCurrentUsername());
            var res =  await _userManager.IsInRoleAsync(user, "Admin");
            if(res){
                context.Succeed(requirement);
            }
            
            return;


            // if (userId == null) return Task.CompletedTask;
            // var toDoId = _httpContextAccessor.HttpContext?.Request.RouteValues
            //     .SingleOrDefault(x => x.Key == "id").Value?.ToString();

            // if(toDoId == "1"){
            //     context.Succeed(requirement);
            // }
            // else{
            //      return Task.CompletedTask;
            // }

            // // var activityId = Guid.Parse(_httpContextAccessor.HttpContext?.Request.RouteValues
            // //     .SingleOrDefault(x => x.Key == "id").Value?.ToString());

            // // // var attendee = _dbContext.ActivityAttendees
            // // //     .AsNoTracking()
            // // //     .FirstOrDefaultAsync(x => x.AppUserId == userId && x.ActivityId == activityId)
            // // //     .Result;

            // // // if (attendee == null) return Task.CompletedTask;

            // // // if (attendee.IsHost) context.Succeed(requirement);

            // return Task.CompletedTask;
        }
    }
}