using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class ActionTrackerAuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Source { get; set; }
		public int TaskID { get; set; }
        public string Action { get; set; }
		public string ActionBy { get; set; }
		public DateTime ActionTime { get; set; }
		public string Comment { get; set; }
    }
}














