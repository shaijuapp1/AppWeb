using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.ToDos.Any()) return;
            
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
    }
}