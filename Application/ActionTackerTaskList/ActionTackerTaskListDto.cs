namespace Application.ActionTackerTaskLists
{
    public class ActionTackerTaskListDto
    {    
		public int Id { get; set; }
		public int ParentID { get; set; }
		public int StatusId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string TaskType { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime ComplectionDate { get; set; }
		public DateTime ActualComplectionDate { get; set; }
		public string Responsibility { get; set; }//User or group
		public string Stakeholder { get; set; }//User or group
		public ICollection<string> ResponsibilityList { get; set; }  = new List<string>();
		public ICollection<string> StakeholderList { get; set; }  = new List<string>();
		public string DetailsJson { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string ActionTitle { get; set; }
		public string ActionComment { get; set; }
    }
} 
