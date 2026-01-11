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
    }
}
