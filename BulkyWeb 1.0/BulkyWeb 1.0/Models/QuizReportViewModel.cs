namespace BulkyWeb_1._0.Models
{
    public class QuizReportViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Correct_Answer { get; set; }
        public bool IsAnswerCorrect { get; set; } // New property to indicate correctness
    }
}
