using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class DataSecurity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int TableId { get; set; }
		public int StatusId { get; set; }
		public string AccessType { get; set; }
		public int FiledId { get; set; }
		public string UserListID { get; set; }
		public string Access { get; set; }
    }
}














