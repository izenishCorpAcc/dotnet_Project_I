using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyWeb_1._0.Models
{
    public class Prasna
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Question_ID { get; set; }
        [Required]

        public string Question { get; set; }
        [Required]

        public string Correst_Answer { get; set; }
        [Required]

        public string WrongAnswer_1 { get; set; }
        [Required]

        public string WrongAnswer_2 { get; set; }
        [Required]

        public string WrongAnswer_3 { get; set; }
        
    }
}
