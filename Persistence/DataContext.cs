using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
     public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ToDoAssignedTo> ToDoAssignedTos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //primary key
            builder.Entity<ToDoAssignedTo>(x => x.HasKey(aa => new { aa.AppUserId, aa.ToDoId }));

            //realation form both sides for may to many relationship
            builder.Entity<ToDoAssignedTo>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.ToDoAssignedTo)
                .HasForeignKey(aa => aa.AppUserId); //forin key

             builder.Entity<ToDoAssignedTo>()
                .HasOne(u => u.ToDo)
                .WithMany(u => u.AssignedTo)
                .HasForeignKey(aa => aa.ToDoId); //forin key

        }
    }
}