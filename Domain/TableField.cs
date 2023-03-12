using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class TableField
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int TableId { get; set; }
		public string Title { get; set; }
		public string FiledType { get; set; }
		public string FideldName { get; set; }
		public int DataSecurityId { get; set; }
		public bool Required { get; set; }
		public int CustomValidationId { get; set; }
    }
}














