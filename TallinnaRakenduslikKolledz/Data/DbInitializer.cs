using TallinnaRakenduslikKolledz.Models;

namespace TallinnaRakenduslikKolledz.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            if (context.Students.Any()) { return; }

            var students = new Student[]
            {
                new Student{FirstName = "George", LastName = "Teemus", EnrollmentDate = DateTime.Now},
                new Student{FirstName = "Abra", LastName = "Kadabra", EnrollmentDate = DateTime.Now},
                new Student{FirstName = "Nipi", LastName = "Tiri", EnrollmentDate = DateTime.Now},
                new Student{FirstName = "Ba", LastName = "Zooka", EnrollmentDate = DateTime.Now},
                new Student{FirstName = "Pori", LastName = "Kärbes", EnrollmentDate = DateTime.Now},
                new Student{FirstName = "Tori", LastName = "Hobune", EnrollmentDate = DateTime.Now},
                new Student{FirstName = "Alev", LastName = "Ström", EnrollmentDate = DateTime.Now},
                new Student{FirstName = "Super", LastName = "Mario", EnrollmentDate = DateTime.Now}
            };
            context.Students.AddRange(students);
            context.SaveChanges();
            if (context.Courses.Any()) { return; }
            var course = new Course[]
            {
                new Course { CourseID=1001, Title="Programmeerimise alused", Credits=3},
                new Course { CourseID=2002, Title="Programmeerimise 1", Credits=3},
                new Course { CourseID=3003, Title="Programmeerimise 2", Credits=3},
                new Course { CourseID=4001, Title="Tarkvara Arendusprotsess", Credits=3},
                new Course { CourseID=1002, Title="Multimeedia", Credits=3},
                new Course { CourseID=3001, Title="Hajusrakenduste alused", Credits=3},
                new Course { CourseID=9001, Title="Cryptobro 101", Credits=0}
            };
            context.Courses.AddRange(course);
            context.SaveChanges();
            if (context.Enrollments.Any()) { return; }
            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1, CourseID=3003, CurrentGrade=Grade.X},
                new Enrollment{StudentID=1, CourseID=3001, CurrentGrade=Grade.B},
                new Enrollment{StudentID=2, CourseID=1001, CurrentGrade=Grade.A},
                new Enrollment{StudentID=2, CourseID=3002, CurrentGrade=Grade.MA},
                new Enrollment{StudentID=3, CourseID=1001, CurrentGrade=Grade.C},
                new Enrollment{StudentID=3, CourseID=2003, CurrentGrade=Grade.C},
                new Enrollment{StudentID=4, CourseID=1002, CurrentGrade=Grade.D},
                new Enrollment{StudentID=4, CourseID=2003, CurrentGrade=Grade.F},
                new Enrollment{StudentID=5, CourseID=2003, CurrentGrade=Grade.F},
                new Enrollment{StudentID=5, CourseID=2003, CurrentGrade=Grade.F},
                new Enrollment{StudentID=6, CourseID=3003, CurrentGrade=Grade.X},
                new Enrollment{StudentID=6, CourseID=3001, CurrentGrade=Grade.B},
                new Enrollment{StudentID=7, CourseID=1001, CurrentGrade=Grade.A},
                new Enrollment{StudentID=7, CourseID=3002, CurrentGrade=Grade.MA}
            };
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
            if (context.Instructors.Any()) { return; }
            var instructors = new Instructor[]
            {
                new Instructor{FirstName="Donkeh", LastName="Dragon", HireDate=DateTime.Now, Age=33},
                new Instructor{FirstName="Shrek", LastName="Öger", HireDate=DateTime.Now, Age=23},
                new Instructor{FirstName="Georeg", LastName="Teemus", HireDate=DateTime.Now, Age=52}
            };
            context.Instructors.AddRange(instructors);
            context.SaveChanges();
        }
    }
}
