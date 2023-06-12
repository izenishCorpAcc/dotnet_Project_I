using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

class HelloWorld
{
    static void Main()
    {
        List<int> l1 = new List<int>() { 9, 8, 6, 0, 4, 6, 5, 5, 4, 0 };
        Console.WriteLine("Query Syntax");

        var test =( from obj in l1 where obj > 2 select obj).ToList();

        foreach (var x in test)
        {
            Console.WriteLine(x);
        }
        Console.WriteLine("---------------");
        Console.WriteLine("Method Syntax");
        var MethodSyntax = l1.Where(x => x > 2);
        foreach (var xx in MethodSyntax)
        {
            Console.WriteLine(xx);
        }
        Console.WriteLine("---------------");
        Console.WriteLine("Mixed Syntax");
        var mixedSyntax = (from obj in l1 select obj).Max();
        Console.WriteLine(mixedSyntax);
        Console.WriteLine("------------------");

        List<Prasna> prasna = new List<Prasna>()
        {
            new Prasna { Question_ID =1,Question="9*9",Correst_Answer="81",WrongAnswer_1="8",WrongAnswer_2="88",WrongAnswer_3="79"},
            new Prasna { Question_ID =2,Question="Capital Of Nepal",Correst_Answer="Kathmandu",WrongAnswer_1="Bhaktapur",WrongAnswer_2="Nuwakot",WrongAnswer_3="Dharan"}
        };

        IEnumerable<Prasna> query = from question in prasna
                                    where question.Question_ID==2
                                    select question;
        foreach (var x in query)
        {
            Console.WriteLine("QuestionId:"+x.Question_ID);
            Console.WriteLine("Question:"+x.Question);
            Console.WriteLine("CorrectAns:"+x.Correst_Answer);
        }
        Console.WriteLine("------------------");

        IQueryable<Prasna> query1 = prasna.AsQueryable().Where(x => x.Question_ID == 1);
        foreach (var x in query1)
        {
            Console.WriteLine("QuestionId:" + x.Question_ID);
            Console.WriteLine("Question:" + x.Question);
            Console.WriteLine("CorrectAns:" + x.Correst_Answer);
        }

    }

    public class Prasna
    {
        [Key]
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

    public class QuizResult
    {
        [Key]
        public int QuizResult_ID { get; set; }
        public string User_ID { get; set; }

        [ForeignKey("Prasna")]
        public int Question_ID { get; set; }

        public string Answer { get; set; }
    }
}
