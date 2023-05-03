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
               
        List<QList> objQuestionsList=_db.QuestionList.ToList();
            return View(objQuestionsList);
        }
        public IActionResult QuizCreate() {
            return View();
        }
    }
}

