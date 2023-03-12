namespace Application.TableFields
{
    public class TableFieldDto
    {
        
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
