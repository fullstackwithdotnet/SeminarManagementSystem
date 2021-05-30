using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeminarManagementSystem.Data;
using SeminarManagementSystem.Models;

namespace SeminarManagementSystem.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public Seminar SelectedSeminar { get; set; }

        public AttendeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attendees
        [HttpGet("Seminar/{id}/Attendees")]
        public async Task<IActionResult> Index(int id)
        {

            var attendees = await _context.Attendees.Include(a => a.Seminar).Where(a => a.Seminar.Seminar_Id == id).ToListAsync();


            ViewBag.Seminar = await _context.Seminars.Where(s => s.Seminar_Id == id).FirstOrDefaultAsync();


            return View(attendees);
        }

        // GET: Attendees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendees
                .FirstOrDefaultAsync(m => m.Attendee_Id == id);
            if (attendee == null)
            {
                return NotFound();
            }

            return View(attendee);
        }

        // GET: Attendees/Create
        [HttpGet("Seminar/{id}/Attendees/new")]
        public async Task<IActionResult> Create(int id)
        {
            var seminar = await _context.Seminars.Where(s => s.Seminar_Id == id).FirstOrDefaultAsync();
            return View(new Attendee() { Seminar = seminar, Date_Of_Birth = DateTime.Now });
        }

        // POST: Attendees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Seminar/{id}/Attendees/new")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, Attendee attendee)
        {
            if (ModelState.IsValid)
            {
                attendee.Seminar = await _context.Seminars.Where(s => s.Seminar_Id == id).FirstOrDefaultAsync();
                _context.Add(attendee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Attendees", new { id });
            }
            return View(attendee);
        }

        // GET: Attendees/Edit/5
        [HttpGet("Seminar/{sid}/Attendees/Edit/{id}")]
        public async Task<IActionResult> Edit(int sid, int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendees.FindAsync(id);
            if (attendee == null)
            {
                return NotFound();
            }
            ViewBag.sid = sid;
            return View(attendee);
        }

        // POST: Attendees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("Seminar/{sid}/Attendees/Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int sid, int id, Attendee attendee)
        {
            if (id != attendee.Attendee_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(attendee);
                    await _context.SaveChangesAsync();
                    var attendees = await _context.Attendees.Include(a => a.Seminar).ToListAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendeeExists(attendee.Attendee_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
              
                return RedirectToAction("Index", "Attendees", new { id = sid });
            }
            return View(attendee);
        }

        // GET: Attendees/Delete/5
        [HttpGet("Seminar/{sid}/Attendees/Delete/{id}")]
        public async Task<IActionResult> Delete(int sid,int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var attendee = await _context.Attendees
                .FirstOrDefaultAsync(m => m.Attendee_Id == id);
            if (attendee == null)
            {
                return NotFound();
            }
            ViewBag.sid = sid;
            return View(attendee);
        }

        // POST: Attendees/Delete/5
        [HttpPost("Seminar/{sid}/Attendees/Delete/{id}"), ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int sid, int id)
        {
            var attendee = await _context.Attendees.FindAsync(id);
            _context.Attendees.Remove(attendee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Attendees", new { id = sid });
        }

        private bool AttendeeExists(int id)
        {
            return _context.Attendees.Any(e => e.Attendee_Id == id);
        }
    }
}
