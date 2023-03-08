using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace Domain
{
    public class ToDoAssignedTo
    {
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ToDoId { get; set; }
        public ToDo ToDo { get; set; }   
        public bool IsCreatedBy { get; set; }
    }
}