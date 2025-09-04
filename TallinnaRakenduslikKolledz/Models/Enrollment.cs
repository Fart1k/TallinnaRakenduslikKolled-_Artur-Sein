namespace TallinnaRakenduslikKolledz.Models
{
    public enum Grade
    {
        A, B, C, D, F, X, MA
    }
    
    
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Grade Grade { get; set; }
    }
}
