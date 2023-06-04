using System.ComponentModel.DataAnnotations;

namespace ForekOnlineApplication.Models
{
    public class Applicant
    {
        [Key]
        public Guid? ApplicanId { get; set; }


        //Relationships
        //public Guid PersonId { get; set; }
        //public Person Person { get; set; }
        //public Qualification Qualification { get; set; }
        //public HighSchool HighSchool { get; set; }
        //public Guid? InstitutionId { get; set; }
        //public Institution Institution { get; set; }
        //public ICollection<Course> Courses { get; set; }
    }
}
