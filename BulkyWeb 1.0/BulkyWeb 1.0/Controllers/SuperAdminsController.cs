﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BulkyWeb_1._0.Data;
using BulkyWeb_1._0.Models;

namespace BulkyWeb_1._0.Controllers
{
    public class SuperAdminsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperAdminsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperAdmins
        public async Task<IActionResult> Index()
        {
              return _context.superAdmins != null ? 
                          View(await _context.superAdmins.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.superAdmins'  is null.");
        }

        // GET: SuperAdmins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.superAdmins == null)
            {
                return NotFound();
            }

            var superAdmin = await _context.superAdmins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superAdmin == null)
            {
                return NotFound();
            }

            return View(superAdmin);
        }

        // GET: SuperAdmins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SuperAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Mobile,Email,Source")] SuperAdmin superAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superAdmin);
        }

        // GET: SuperAdmins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.superAdmins == null)
            {
                return NotFound();
            }

            var superAdmin = await _context.superAdmins.FindAsync(id);
            if (superAdmin == null)
            {
                return NotFound();
            }
            return View(superAdmin);
        }

        // POST: SuperAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Mobile,Email,Source")] SuperAdmin superAdmin)
        {
            if (id != superAdmin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperAdminExists(superAdmin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(superAdmin);
        }

        // GET: SuperAdmins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.superAdmins == null)
            {
                return NotFound();
            }

            var superAdmin = await _context.superAdmins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (superAdmin == null)
            {
                return NotFound();
            }

            return View(superAdmin);
        }

        // POST: SuperAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.superAdmins == null)
            {
                return Problem("Entity set 'ApplicationDbContext.superAdmins'  is null.");
            }
            var superAdmin = await _context.superAdmins.FindAsync(id);
            if (superAdmin != null)
            {
                _context.superAdmins.Remove(superAdmin);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperAdminExists(int id)
        {
          return (_context.superAdmins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
