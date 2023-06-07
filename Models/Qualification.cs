using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForekOnlineApplication.Models
{
    public class Qualification
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }

        public string QualificationName { get; set; }
        public string QualificationDescription { get; set; }
        public string QualificationType { get; set; }
        public string Level { get; set; }

        //Relationship
        //public Guid ApplicantId { get; set; }
        //public Applicant Applicant { get; set; }
    }
}
