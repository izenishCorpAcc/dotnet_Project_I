using System.ComponentModel.DataAnnotations;

namespace BulkyWeb_1._0.Models
{
    public class QList
    {
        [Key]
        public int Question_ID { get; set; }
        [Required]
        
        public string Question { get; set; }
        public string Correst_Answer { get; set; }
        public string WrongAnswer_1{ get; set; }
        public string WrongAnswer_2 { get; set; }
        public string WrongAnswer_3 { get; set; }



    }
}
