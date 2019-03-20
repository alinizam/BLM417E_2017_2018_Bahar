using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CoursesNotesController : Controller
    {
        private readonly bioContext _context;

        public CoursesNotesController(bioContext context)
        {
            _context = context;
        }

        // GET: CoursesNotes
        public async Task<IActionResult> Index()
        {
            var bioContext = _context.CoursesNotes.Include(c => c.StudentCourse);
            return View(await bioContext.ToListAsync());
        }

        // GET: CoursesNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesNotes = await _context.CoursesNotes
                .Include(c => c.StudentCourse)
                .SingleOrDefaultAsync(m => m.CourseNoteId == id);
            if (coursesNotes == null)
            {
                return NotFound();
            }

            return View(coursesNotes);
        }

        // GET: CoursesNotes/Create
        public IActionResult Create()
        {
            ViewData["StudentCourseId"] = new SelectList(_context.StudentCourses, "StudentCourseId", "StudentCourseId");
            return View();
        }

        // POST: CoursesNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseNoteId,ExamName,StudentCourseId")] CoursesNotes coursesNotes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coursesNotes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentCourseId"] = new SelectList(_context.StudentCourses, "StudentCourseId", "StudentCourseId", coursesNotes.StudentCourseId);
            return View(coursesNotes);
        }

        // GET: CoursesNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesNotes = await _context.CoursesNotes.SingleOrDefaultAsync(m => m.CourseNoteId == id);
            if (coursesNotes == null)
            {
                return NotFound();
            }
            ViewData["StudentCourseId"] = new SelectList(_context.StudentCourses, "StudentCourseId", "StudentCourseId", coursesNotes.StudentCourseId);
            return View(coursesNotes);
        }

        // POST: CoursesNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseNoteId,ExamName,StudentCourseId")] CoursesNotes coursesNotes)
        {
            if (id != coursesNotes.CourseNoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coursesNotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursesNotesExists(coursesNotes.CourseNoteId))
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
            ViewData["StudentCourseId"] = new SelectList(_context.StudentCourses, "StudentCourseId", "StudentCourseId", coursesNotes.StudentCourseId);
            return View(coursesNotes);
        }

        // GET: CoursesNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesNotes = await _context.CoursesNotes
                .Include(c => c.StudentCourse)
                .SingleOrDefaultAsync(m => m.CourseNoteId == id);
            if (coursesNotes == null)
            {
                return NotFound();
            }

            return View(coursesNotes);
        }

        // POST: CoursesNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coursesNotes = await _context.CoursesNotes.SingleOrDefaultAsync(m => m.CourseNoteId == id);
            _context.CoursesNotes.Remove(coursesNotes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursesNotesExists(int id)
        {
            return _context.CoursesNotes.Any(e => e.CourseNoteId == id);
        }
    }
}
