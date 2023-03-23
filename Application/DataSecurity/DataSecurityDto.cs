namespace Application.DataSecuritys
{
    public class DataSecurityEditDto
    {
        
		public int Id { get; set; }
		public int TableId { get; set; }
		public int StatusId { get; set; }
		public string AccessType { get; set; }
		public int FiledId { get; set; }
		public int UserID { get; set; }
		public string Access { get; set; }   
    }

	public class DataSecurityDto
    {        
		public int Id { get; set; }
		public int TableId { get; set; }
		public string AccessType { get; set; }
		public string Access { get; set; }
		public ICollection<string> UserID { get; set; }  = new List<string>();	
		public string UserListID { get; set; }

    }

	// public class UserGrp
    // {        
	// 	public int Id { get; set; }
	// }
}
