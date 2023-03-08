using Microsoft.AspNetCore.Identity;
 
namespace Domain
{
    public class AppUser : IdentityUser
    {
         public bool IsActive { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public ICollection<ToDoAssignedTo> ToDoAssignedTo { get; set; }
    }
}