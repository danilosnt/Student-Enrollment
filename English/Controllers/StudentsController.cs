using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Data;
using StudentEnrollment.Models;

namespace StudentEnrollment.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        // Renomeado searchTerm e referências de propriedade (Name, Address)
        public async Task<IActionResult> Index(string searchTerm)
        {
            var students = from s in _context.Students
                           select s;

            if (!String.IsNullOrEmpty(searchTerm))
            {
                students = students.Where(s => s.Name.Contains(searchTerm)
                                            || s.CPF.Contains(searchTerm)
                                            || s.Address.Contains(searchTerm));
            }

            return View(await students.OrderBy(e => e.Name).ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Bind] atualizado para novas propriedades
        public async Task<IActionResult> Create([Bind("Id,Name,CPF,Address,CompletionDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(student);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Student created successfully!"; // Traduzido
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx &&
                       (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                    {
                        ModelState.AddModelError("CPF", "This CPF is already registered in our system."); // Traduzido
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "An error occurred while saving the data."); // Traduzido
                    }
                }
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Bind] atualizado para novas propriedades
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CPF,Address,CompletionDate")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Student updated successfully!"; // Traduzido
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx &&
                       (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                    {
                        ModelState.AddModelError("CPF", "This CPF is already registered in our system."); // Traduzido
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "An error occurred while saving changes."); // Traduzido
                    }
                }
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Student deleted successfully!"; // Traduzido
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
}