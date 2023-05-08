﻿ using BulkyWeb_1._0.Data;
using BulkyWeb_1._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb_1._0.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
            
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList=_db.Categories.ToList();
            return View(objCategoryList);
        }

        //IF HTTPPOST isn't defined then by default its a GET method
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The fields can't be the same");
            }
            if (ModelState.IsValid) 
            { 
            _db.Categories.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            }
            return View();
          
        }
        //For EDIT
        public IActionResult Edit(int? id)
        {
            if(id == null||id==0)
            {
                return NotFound();
            }
            Category? categoryFromDB = _db.Categories.FirstOrDefault(c => c.Id == id);
           
            if(categoryFromDB != null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The fields can't be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

    }
}
