﻿using BulkyWeb_1._0.Data;
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
            TempData["success"] = "Question added successfully";

            return RedirectToAction("Index");
            }
            return View();

        }
        //EDIT
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

        
    }
}

