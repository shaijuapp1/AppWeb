using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class TableData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public int TableId { get; set; }
        public string Txt1 { get; set; }
        public string Txt2 { get; set; }
        public string Txt3 { get; set; }
        public string Txt4 { get; set; }
        public string Txt5 { get; set; }
        public string Txt6 { get; set; }
        public string Txt7 { get; set; }
        public string Txt8 { get; set; }
        public string Txt9 { get; set; }
        public string Txt10 { get; set; }
        public string Txt11 { get; set; }
        public string Txt12 { get; set; }
        public string Txt13 { get; set; }
        public string Txt14 { get; set; }
        public string Txt15 { get; set; }
        public string Txt16 { get; set; }
        public string Txt17 { get; set; }
        public string Txt18 { get; set; }
        public string Txt19 { get; set; }
        public string Txt20 { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public DateTime Date3 { get; set; }
        public DateTime Date4 { get; set; }
        public DateTime Date5 { get; set; }
        public DateTime Date6 { get; set; }
        public DateTime Date7 { get; set; }
        public DateTime Date8 { get; set; }
        public DateTime Date9 { get; set; }
        public DateTime Date10 { get; set; }
        public float Num1 { get; set; }
        public float Num2 { get; set; }
        public float Num3 { get; set; }
        public float Num4 { get; set; }
        public float Num5 { get; set; }
        public float Num6 { get; set; }
        public float Num7 { get; set; }
        public float Num8 { get; set; }
        public float Num9 { get; set; }
        public float Num10 { get; set; }
        public int User1 { get; set; }
        public int User2 { get; set; }
        public int User3 { get; set; }
        public int User4 { get; set; }
        public int User5 { get; set; }
        public int User6 { get; set; }
        public int User7 { get; set; }
        public int User8 { get; set; }
        public int User9 { get; set; }
        public int User10 { get; set; }
    }
}














