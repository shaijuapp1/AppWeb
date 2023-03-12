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
        public DbSet<AppConfigType> AppConfigTypes { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
		public DbSet<TableName> TableNames { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<TableData> TableDatas { get; set; }
		public DbSet<TableField> TableFields { get; set; }
		public DbSet<DataSecurity> DataSecuritys { get; set; }
		//##ModelDbSet##

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



