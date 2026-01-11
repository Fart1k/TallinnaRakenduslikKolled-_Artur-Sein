using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class DelinquentsController : Controller
    {
        private readonly SchoolContext _context;
        public DelinquentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var delinquents = await _context.Delinquents.ToListAsync();
            return View(delinquents);
        }

        // Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID, FirstName, LastName, Violation, IsTeacher, ViolationDescription" )] Delinquents delinquents)
        {
            if (ModelState.IsValid)
            {
                _context.Delinquents.Add(delinquents);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        // Details
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(m => m.ID == id);
            if (id == null)
            {
                return NotFound();
            }
            if (delinquent == null)
            {
                return NotFound();
            }
            return View(delinquent);
        }

        // Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(m => m.ID == id);
            if (id == null)
            {
                return NotFound();
            }
            if (delinquent == null)
            {
                return NotFound();
            }
            _context.Delinquents.Update(delinquent);
            return View(delinquent);
        }

        [HttpPost, ValidateAntiForgeryToken, ActionName("Edit")]
        public async Task<IActionResult> EditConfirmed(int id,
            [Bind("ID, FirstName, LastName, Violation, IsTeacher, ViolationDescription")] Delinquents delinquents)
        {
            _context.Delinquents.Update(delinquents);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var delinquent = await _context.Delinquents.FirstOrDefaultAsync(m => m.ID == id);

            if (delinquent == null)
            {
                return NotFound();
            }
            return View(delinquent);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delinquent = await _context.Delinquents.FindAsync(id);
            _context.Delinquents.Remove(delinquent);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
