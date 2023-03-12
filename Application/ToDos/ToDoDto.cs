
using Application.Profiles;

namespace Application.ToDos
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime TragetDate { get; set; }  
        public string CreatedBy { get; set; }
        public ICollection<Profile> AssignedTo { get; set; }   
    }
}