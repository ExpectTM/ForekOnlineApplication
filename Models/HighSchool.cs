using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForekOnlineApplication.Models
{
    public class HighSchool
    {
        [Key]
        public Guid HighSchoolId { get; set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }

        public string HighSchoolName { get; set;}
        public int GradePassed { get; set;}

        //Relationship
        //public Guid? ApplicantId { get; set; }
        //public Applicant? Applicant { get; set; }  
    }
}
