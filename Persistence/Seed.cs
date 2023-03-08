using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class Seed
    {
          public static async Task SeedData(DataContext context,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {

            if (!userManager.Users.Any() )
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com",
                        IsActive = true
                    },
                    new AppUser
                    {
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com",
                        IsActive = true
                    },
                    new AppUser
                    {
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com",
                        IsActive = true 
                    },
                    new AppUser
                    {
                        DisplayName = "Admin",
                        UserName = "admin",
                        Email = "admin@test.com",
                        IsActive = true 
                       
                    },
                    new AppUser
                    {
                        DisplayName = "Test1",
                        UserName = "test1",
                        Email = "test1@test.com",
                        IsActive = true 
                       
                    },
                    new AppUser
                    {
                        DisplayName = "Test2",
                        UserName = "test2",
                        Email = "test2@test.com",
                        IsActive = true 
                    },
                    new AppUser
                    {
                        DisplayName = "Test3",
                        UserName = "test3",
                        Email = "test3@test.com",
                        IsActive = true 
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            
            if (!context.ToDos.Any()) 
            {
                
                var todos = new List<ToDo>
                {
                    new ToDo
                    {
                        Title = "Past Activity 1",
                        TragetDate = DateTime.UtcNow.AddMonths(2),                    
                    },
                    new ToDo
                    {
                        Title = "Past Activity 2",
                        TragetDate = DateTime.UtcNow.AddMonths(1),                    
                    },
                    new ToDo
                    {
                        Title = "Future Activity 1",
                        TragetDate = DateTime.UtcNow.AddMonths(1),                    
                    },
                    new ToDo
                    {
                        Title = "Future Activity 2",
                        TragetDate = DateTime.UtcNow.AddMonths(2),                    
                    }
                };

                await context.ToDos.AddRangeAsync(todos);
                await context.SaveChangesAsync();
            }

            
            if (!roleManager.Roles.Any())
            {
                
                
                var users = new List<AppUser>
                {                   
                    new AppUser
                    {
                        DisplayName = "Admin",
                        UserName = "admin",
                        Email = "admin@test.com",
                        IsActive = true 
                       
                    },
                    new AppUser
                    {
                        DisplayName = "Test1",
                        UserName = "test1",
                        Email = "test1@test.com",
                        IsActive = true 
                       
                    },
                    new AppUser
                    {
                        DisplayName = "Test2",
                        UserName = "test2",
                        Email = "test2@test.com",
                        IsActive = true 
                    },
                    new AppUser
                    {
                        DisplayName = "Test3",
                        UserName = "test3",
                        Email = "test3@test.com",
                        IsActive = true 
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
           

                 if (!await roleManager.RoleExistsAsync( "Admin")) {
                    var role = new IdentityRole();    
                    role.Name = "Admin";    
                    await roleManager.CreateAsync(role);   

                    var user = await context.Users.FirstOrDefaultAsync( u => u.UserName == "admin"  );                     
                    if (user != null){
                      await userManager.AddToRoleAsync(user, "Admin" );

                      var success = await context.SaveChangesAsync() > 0;

                    }                                                                                               
                } 

                 if (!await roleManager.RoleExistsAsync( "All Users")) {
                    var role = new IdentityRole();    
                    role.Name = "All Users";    
                    await roleManager.CreateAsync(role);   

                    var user = await context.Users.FirstOrDefaultAsync( u => u.UserName == "admin"  );                     
                    if (user != null){
                      await userManager.AddToRoleAsync(user, "All Users" );
                    }
                    user = await context.Users.FirstOrDefaultAsync( u => u.UserName == "test1"  );                     
                    if (user != null){
                      await userManager.AddToRoleAsync(user, "All Users" );
                    } 
                    user = await context.Users.FirstOrDefaultAsync( u => u.UserName == "test2"  );                     
                    if (user != null){
                      await userManager.AddToRoleAsync(user, "All Users" );
                    } 
                    user = await context.Users.FirstOrDefaultAsync( u => u.UserName == "test3"  );                     
                    if (user != null){
                      await userManager.AddToRoleAsync(user, "All Users" );
                    }
                } 
            }


          
        }
    }
}