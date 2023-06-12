using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyWeb_1._0.Models
{
    public class QuizResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizResult_ID { get; set; }
        public string User_ID { get; set; }
        public int Question_ID { get; set; }
        public string Answer { get; set; }

        [ForeignKey("Question_ID")]
        public Prasna Prasna { get; set; }
    }
}
