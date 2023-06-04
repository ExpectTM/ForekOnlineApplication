using System.ComponentModel.DataAnnotations;

namespace ForekOnlineApplication.Models
{
    public class HighSchool
    {
        [Key]
        public Guid HighSchoolId { get; set; }
        public string HighSchoolName { get; set;}
        public int GradePassed { get; set;}

        //Relationship
        //public Guid? ApplicantId { get; set; }
        //public Applicant? Applicant { get; set; }  
    }
}
