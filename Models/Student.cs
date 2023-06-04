using System.ComponentModel.DataAnnotations;

namespace ForekOnlineApplication.Models
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        public string StudentNumber { get; set; }

        //Relationship
        //public Enrolment Enrolment { get; set; }
        //public Course Course { get; set; }
        //public Guid MedicalId { get; set; }
        //public Medical Medical { get; set; }

    }
}
