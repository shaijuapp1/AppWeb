namespace Application.ActionTrackerAuditLogs
{
    public class ActionTrackerAuditLogDto
    {
        
		public int Id { get; set; }
		public int TaskID { get; set; }
		public string Source { get; set; }
		public string Action { get; set; }
		public string ActionBy { get; set; }
		public string ActionTime { get; set; }
		public string Comment { get; set; }   
    }
}
