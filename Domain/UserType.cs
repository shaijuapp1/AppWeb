using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class UserType
    {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      public string Type { get; set; }
      public string UserId { get; set; }
      public string GrpId { get; set; }
      // public string TableID { get; set; }
      // public string FiledID { get; set; }

    }
}














