using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;
        public StudentsController(SchoolContext context) 
        { 
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind
            ("Id, FirstName, LastName, Gender, EnrollmentDate, Age, email")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
                // return RedirectToAction(nameof(Index))
            }
            return View(student);
        }
        //Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == Id);
            if (Id == null)
            {
                return NotFound();
            }
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Update(student);
            return View(student);
        }
        [HttpPost, ValidateAntiForgeryToken, ActionName("Edit")]
        public async Task<IActionResult> Edit(int id, [Bind("Id, LastName, FirstName")] Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //Details
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(m => m.Id == id);
            return View(student);
        }
    }
}
