using System.ComponentModel.DataAnnotations;

namespace ForekOnlineApplication.Models
{
    public class Qualification
    {
        [Key]
        public Guid Id { get; set; }
        public string QualificationName { get; set; }
        public string QualificationDescription { get; set; }
        public string QualifacationType { get; set; }
        public string Level { get; set; }

        //Relationship
        //public Guid ApplicantId { get; set; }
        //public Applicant Applicant { get; set; }
    }
}
