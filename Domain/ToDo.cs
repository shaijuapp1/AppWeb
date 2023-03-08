using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime TragetDate { get; set; }      
        //public AppUser CreatedBy { get; set; }    
        public ICollection<ToDoAssignedTo> AssignedTo { get; set; }  = new List<ToDoAssignedTo>();

    }
}