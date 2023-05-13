using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ActionTackerTypesList
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Title { get; set; }
		public string TypeID { get; set; }
		public string ActionType { get; set; }
		public string ParentID { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int StatusId { get; set; }
		public string ActionCreaedBy { get; set; }
		public DateTime ActionCreatedTime { get; set; }
		public DateTime ActionModifiedTime { get; set; }
		public string DetailsJson { get; set; }
		public string ProjectOwner { get; set; } //User
		public string StakeHolders { get; set; } //User or group
		//public string test { get; set; }
    }
}














