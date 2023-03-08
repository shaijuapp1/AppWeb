using System.Text;

using Domain;

using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
//using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Infrastructure.Security;
using API.Services;
using Persistence;
using Infrastructure.Security;
using Microsoft.AspNetCore.Identity;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {

             var builder = services.AddIdentityCore<AppUser>();
            // var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
            // identityBuilder.AddRoles<IdentityRole>();


            services.AddIdentityCore<AppUser>(opt =>
            {                
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = true;                
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<DataContext>();

            
            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("IsDevAdmin", policy =>
                {
                    policy.Requirements.Add(new IsHostRequirement());
                });
            });

            services.AddTransient<IAuthorizationHandler, IsHostRequirementHandler>();
            services.AddScoped<TokenService>();

            return services;
        }
    }
}