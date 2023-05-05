using BulkyWeb_1._0.Data;
using BulkyWeb_1._0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb_1._0.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _db;
        public QuizController(ApplicationDbContext db)
        {
            _db = db;
        }
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
        public IActionResult QuizCreate(Prasna obj)
        {
            if (ModelState.IsValid) { 
            _db.Prasna.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();

        }
    }
}

