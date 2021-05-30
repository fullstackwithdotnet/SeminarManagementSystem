using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeminarManagementSystem.Data;
using SeminarManagementSystem.Models;
using SeminarManagementSystem.ViewModels;

namespace SeminarManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Home
        public async Task<IActionResult> Index()
        {
            var organizers = await _context.Organizers.ToListAsync();
            if (organizers.Count > 0)
                return View(await _context.Seminars.Include(s => s.Organizer).Include(s => s.Type).ToListAsync());
            else
                return RedirectToAction("Index", "Organizers");
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seminar = await _context.Seminars
                .FirstOrDefaultAsync(m => m.Seminar_Id == id);
            if (seminar == null)
            {
                return NotFound();
            }

            return View(seminar);
        }

        // GET: Home/Create
        public async Task<IActionResult> Create()
        {
            var model = new AddSeminarViewModel()
            {
                Organizers = new List<SelectListItem>(),
                Types = new List<SelectListItem>()
               
            };

            var organizers = await _context.Organizers.ToListAsync();
            var types = await _context.Types.ToListAsync();
            organizers.ForEach(o =>
            {
                model.Organizers.Add(new SelectListItem { Value = o.Organizer_Id.ToString(), Text = o.Name });

            });
            types.ForEach(t =>
            {
                model.Types.Add(new SelectListItem { Value = t.Type_Id.ToString(), Text = t.Type_Name });

            });
            return View(model);
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddSeminarViewModel seminarModel)
        {
            if (ModelState.IsValid)
            {
                seminarModel.Seminar.Organizer = await _context.Organizers.FirstOrDefaultAsync(o => o.Organizer_Id == Convert.ToInt32(seminarModel.SelectedOrganizer));
                seminarModel.Seminar.Type = await _context.Types.FirstOrDefaultAsync(o => o.Type_Id == Convert.ToInt32(seminarModel.SelectedType));

                _context.Add(seminarModel.Seminar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seminarModel);
        }

        // GET: Home/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seminar = await _context.Seminars.FindAsync(id);
            if (seminar == null)
            {
                return NotFound();
            }
            return View(seminar);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Seminar_Id,Name,Venue,Seminar_Date,Starting_Time,Ending_Time")] Seminar seminar)
        {
            if (id != seminar.Seminar_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seminar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeminarExists(seminar.Seminar_Id))
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
            return View(seminar);
        }

        // GET: Home/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seminar = await _context.Seminars
                .FirstOrDefaultAsync(m => m.Seminar_Id == id);
            if (seminar == null)
            {
                return NotFound();
            }

            return View(seminar);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seminar = await _context.Seminars.Include(s => s.Attendees).FirstOrDefaultAsync(s => s.Seminar_Id == id);
            if (seminar.Attendees.Any())
            {
                ViewBag.Error = "This seminar has active attendees. You are not allowed to delete.";
                return View();
            }
            _context.Seminars.Remove(seminar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeminarExists(int id)
        {
            return _context.Seminars.Any(e => e.Seminar_Id == id);
        }
    }
}
