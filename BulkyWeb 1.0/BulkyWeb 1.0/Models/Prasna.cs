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
        public string? Question { get; set; }
        [Required]
        [DisplayName("Correct Answer:")]
        public string? Correst_Answer { get; set; }
        [Required]
        [DisplayName("Wrong Answer 1:")]
        public string? WrongAnswer_1 { get; set; }
        [Required]
        [DisplayName("Wrong Answer 2:")]
        public string? WrongAnswer_2 { get; set; }
        [Required]
        [DisplayName("Wrong Answer 3:")]
        public string? WrongAnswer_3 { get; set; }

        public string[] GetShuffledAnswers()
        {
            // create an array of all the answer options
            string[] answers = new string[] { Correst_Answer, WrongAnswer_1, WrongAnswer_2, WrongAnswer_3 };

            // shuffle the answer options using Fisher-Yates shuffle
            Random rand = new Random();
            for (int i = answers.Length - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                string temp = answers[i];
                answers[i] = answers[j];
                answers[j] = temp;
            }
            return answers;


        }
    }
}
