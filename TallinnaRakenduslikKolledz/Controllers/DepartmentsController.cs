using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly SchoolContext _context;
        public DepartmentsController(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Departments.Include(d => d.Administrator);
            return View(await schoolContext.ToListAsync());
        }

        // Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CreateAndEdit"] = "Create";
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Budget, StartDate, RowVersion, InstructorID, StudentsCount, DepartmentStatus")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "Id", "FullName", department.InstructorID);
            return View(department);
        }


        // Edit
        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            ViewData["CreateAndEdit"] = "Edit";
            var department = await _context.Departments.FirstOrDefaultAsync(m => m.DepartmentID == Id);
            if (Id == null)
            {
                return NotFound();
            }
            if (department == null)
            {
                return NotFound();
            }
            _context.Departments.Update(department);
            return View("Create", department);
        }
        [HttpPost, ValidateAntiForgeryToken, ActionName("Edit")]
        public async Task<IActionResult> EditConfirmed(int id, [Bind("Name, Budget, StartDate, StudentsCount, InstructorID")] Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["DeleteAndDetails"] = "Delete";
            if (id == null)
            {
                return NotFound();
            }
            var department = await _context.Departments
                .Include(d => d.Administrator)
                .FirstOrDefaultAsync(d => d.DepartmentID == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Department department)
        {
            if (await _context.Departments.AnyAsync(m => m.DepartmentID == department.DepartmentID))
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // Details
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["DeleteAndDetails"] = "Details";
            if (id == null) 
            {
               return NotFound(); 
            }
            var department = await _context.Departments.FirstOrDefaultAsync(d => d.DepartmentID == id);
            return View(nameof(Delete), department);
        }
    }
}
