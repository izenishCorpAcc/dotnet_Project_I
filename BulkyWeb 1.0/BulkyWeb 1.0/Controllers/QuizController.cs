using BulkyWeb_1._0.Data;
using BulkyWeb_1._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace BulkyWeb_1._0.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuizController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [Authorize(Roles = "admin")]

        public IActionResult Index()
        {
               
        List<Prasna> objQuestionsList=_db.Prasna.ToList();
            return View(objQuestionsList);
          //return View();
        }
        public IActionResult QuizCreate() {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "admin")]

        public IActionResult QuizCreate(Prasna obj)
        {
            var a = obj.Correct_Answer;
            var b = obj.WrongAnswer_1;
            var c = obj.WrongAnswer_2;
            var d = obj.WrongAnswer_3;
            if (a == b || a == c || a == d || b == c || b == d || c == d)
            {
                ModelState.AddModelError("", "The Answers can't have the same value");
            }
                if (ModelState.IsValid) { 
            _db.Prasna.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Question added successfully";

            return RedirectToAction("Index");
            }
            return View();

        }
        //EDIT
        [Authorize(Roles = "admin")]

        public IActionResult Edit(int? id)
        {
            if (id == null||id==0)
            {
                return NotFound();
            }
            Prasna? obj= _db.Prasna.FirstOrDefault(c=>c.Question_ID==id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]

        public IActionResult Edit(Prasna obj)
        {
            if(ModelState.IsValid)
            {
                _db.Prasna.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Question Edited successfully";

                return RedirectToAction("Index");
            }
            return View();
        }
        [Authorize(Roles = "admin")]

        public IActionResult Delete(int? id)
        {
            if (id==null||id==0)
            {
                return NotFound();
            }
            Prasna? obj= _db.Prasna.FirstOrDefault(c=>c.Question_ID==id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);

        }

        [HttpPost,ActionName("Delete")]
        [Authorize(Roles = "admin")]

        public IActionResult DeletePost(int? id)
        {
            Prasna? obj=_db.Prasna.FirstOrDefault(c=> c.Question_ID==id);
            if (obj == null)
            {
                return NotFound();  
            }
            _db.Prasna.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Question deleted successfully";

            return RedirectToAction("Index");
        }

        public IActionResult QA()
        {
            //var questions = _db.Prasna.ToList();
            List<Prasna> questions = _db.Prasna.ToList();
            // shuffle answers for each question
            foreach (var question in questions)
            {
                var shuffledAnswers = question.GetShuffledAnswers();
                ViewData[$"shuffledAnswers_{question.Question_ID}"] = shuffledAnswers;
            }

            return View(questions);
        }
        public IActionResult Q()
        {
            List<Prasna> questions = _db.Prasna.ToList();
            foreach (var question in questions)
            {
                var shuffledAnswers = question.GetShuffledAnswers();
                ViewData["shuffledans"] = shuffledAnswers;
            }
            return View(questions);
        }


        //public IActionResult Results()
        //{

        //        var list = _db.QuizResults.Include("Prasna").ToList();
        //        return View(list);

        //}

        public IActionResult Report()
        {
            var query = from user in _db.Users
                        join quizResult in _db.QuizResults on user.Id equals quizResult.User_ID into quizResultGroup
                        from result in quizResultGroup.DefaultIfEmpty()
                        join question in _db.Prasna on result.Question_ID equals question.Question_ID into questionGroup
                        from questionResult in questionGroup.DefaultIfEmpty()
                        select new QuizReportViewModel
                        {
                            UserId = user.Id,
                            Name = user.Name,
                            UserName = user.UserName,
                            Question = questionResult != null ? questionResult.Question : null,
                            Correct_Answer = questionResult != null ? questionResult.Correct_Answer : null,
                            Answer = result != null ? result.Answer : null,
                            IsAnswerCorrect = (questionResult.Correct_Answer == result.Answer)
                        };

            var resultList = query.ToList();

            return View(resultList);
        }



        //public IActionResult R()
        //{
        //    List<QuizResult> qResult = _db.QuizResults.Select(x=> new()
        //    {
        //        QuizResult_ID=x.QuizResult_ID,

        //    }

        //        ).ToList();
        //    foreach (var question in questions)
        //    {
        //        var shuffledAnswers = question.GetShuffledAnswers();
        //        ViewData["shuffledans"] = shuffledAnswers;
        //    }
        //    return View(questions);
        //}
        public string Qtest(string firstName,string lastName)
        {
            return "From Parameters-"+firstName+" , "+lastName;
        }

        //[HttpPost]
        //public IActionResult SubmitAnswers(IFormCollection form)
        //{
        //    var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //    foreach (var question in form.Keys)
        //    {
        //        var questionId = int.Parse(question);
        //        var selectedAnswer = form[question];
        //        var quizResult = new QuizResult
        //        {
        //            User_ID = userId,
        //            Question_ID = questionId,
        //            Answer = selectedAnswer
        //        };
        //        _db.QuizResults.Add(quizResult);
        //        _db.SaveChanges();


        //    }
        //    return RedirectToAction("Results");
        //}

        [HttpPost]
        public IActionResult SubmitAnswers(IFormCollection form)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var quizResults = new List<QuizResult>();
            foreach (var question in form.Keys)
            {
                var questionId = int.Parse(question);
                var selectedAnswer = form[question];
                var quizResult = new QuizResult
                {
                    User_ID = userId,
                    Question_ID = questionId,
                    Answer = selectedAnswer
                };
                quizResults.Add(quizResult);
            }
            try
            {
                _db.QuizResults.AddRange(quizResults);
                _db.SaveChanges();
                return RedirectToAction("Results");
            }
            catch (Exception ex)
            {
                string errorMessage = "An error occurred while saving the quiz results: ";

                // Check if there is an inner exception
                if (ex.InnerException != null)
                {
                    // Include the inner exception's message
                    errorMessage += ex.InnerException.Message;
                }
                else
                {
                    // If there is no inner exception, include the exception's message
                    errorMessage += ex.Message;
                }

                return BadRequest(errorMessage);
            }

        }




    }
}

