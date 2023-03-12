using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class AppConfig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int ConfigTypeId { get; set; }
		public string Title { get; set; }
		public string Val1 { get; set; }
		public string Val2 { get; set; }
		public string Val3 { get; set; }
		public string Val4 { get; set; }
		public string Val5 { get; set; }
		public int Order { get; set; }
    }
}














