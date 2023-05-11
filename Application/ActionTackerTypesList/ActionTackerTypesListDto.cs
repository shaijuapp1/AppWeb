namespace Application.ActionTackerTypesLists
{
    public class ActionTackerTypesListDto
    {        
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
		public ICollection<string> StakeHoldersList { get; set; }  = new List<string>();
		public string StakeHolders { get; set; } 
		public string ActionTitle { get; set; }
		public string ActionComment { get; set; }

    } 
}
