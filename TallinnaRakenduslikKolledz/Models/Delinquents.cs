using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolledz.Models
{
    public enum Violations
    {
        Robbery,
        Vandalism,
        Assault,
        Trespassing,
        DrugPossession
    }
    public class Delinquents
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Violations Violation { get; set; }
        public bool IsTeacher { get; set; }
        public string ViolationDescription { get; set; }
    }
}
