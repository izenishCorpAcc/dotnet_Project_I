using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyWeb_1._0.Models
{
    public class Prasna
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Question ID:")]
        public int Question_ID { get; set; }
        [Required]
        [DisplayName("Question:")]
        public string Question { get; set; }
        [Required]
        [DisplayName("Correct Answer:")]
        public string Correst_Answer { get; set; }
        [Required]
        [DisplayName("Wrong Answer 1:")]
        public string WrongAnswer_1 { get; set; }
        [Required]
        [DisplayName("Wrong Answer 2:")]
        public string WrongAnswer_2 { get; set; }
        [Required]
        [DisplayName("Wrong Answer 3:")]
        public string WrongAnswer_3 { get; set; }
        
    }
}
