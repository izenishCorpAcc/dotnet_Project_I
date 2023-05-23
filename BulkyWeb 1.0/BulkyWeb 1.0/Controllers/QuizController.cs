using BulkyWeb_1._0.Data;
using BulkyWeb_1._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb_1._0.Controllers
{
    [Authorize]
    public class QuizController : Controller
    {
        
        private readonly ApplicationDbContext _db;
        public QuizController(ApplicationDbContext db)
        {
            _db = db;
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
            var a = obj.Correst_Answer;
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

        
    }
}

