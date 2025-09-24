using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
namespace TallinnaRakenduslikKolledz.Models
{
    public class Department
    {
        public enum DepartmentStatus
        {
            Suletud, Avatud, Pausil 
        }
        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }
        public Instructor? Administrator { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public byte? RowVersion { get; set; }


        ////////
        public int? StudentsCount {  get; set; }
        public string? DepartmentCategory { get; set; }
        public string? BestStudent {  get; set; }

        public DepartmentStatus? CurrentStatus { get; set; }
    }
}
