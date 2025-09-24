﻿using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TallinnaRakenduslikKolledz.Data;
using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolContext _context;
        public InstructorsController(SchoolContext context) 
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            var vm = new InstructorIndexData();
            vm.Instructors = await _context.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                .ToListAsync();
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create ()
        {
            var instructor = new Instructor();
            instructor.CourseAssignments = new List<CourseAssignment>();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Instructor instructor, string selectedCourses)
        {
            if (selectedCourses != null)
            {
                instructor.CourseAssignments = new List<CourseAssignment>();
                foreach (var course in selectedCourses)
                {
                    var courseToAdd = new CourseAssignment
                    {
                        InstructorID = instructor.ID,
                        CourseID = course
                    };
                    instructor.CourseAssignments.Add(courseToAdd);
                }
            }
            ModelState.Remove("selectedCourses");
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
           // PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deletableInstructor = await _context.Instructors
                .FirstOrDefaultAsync(s => s.ID == id);
            if (deletableInstructor == null)
            {
                return NotFound();
            }
            return View(deletableInstructor);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Instructor deletableInstructor = await _context.Instructors
                .SingleAsync(i => i.ID == id);
            _context.Instructors.Remove(deletableInstructor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? ID)
        {
            var instructor = await _context.Instructors.FirstOrDefaultAsync(m => m.ID == ID);
            if (ID == null)
            {
                return NotFound();
            }
            if (instructor == null)
            {
                return NotFound();
            }
            _context.Instructors.Update(instructor);
            return View(instructor);
        }
        [HttpPost, ValidateAntiForgeryToken, ActionName("Edit")]
        public async Task<IActionResult> EditConfirmed(int ID, [Bind("ID, LastName, FirstName")] Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
