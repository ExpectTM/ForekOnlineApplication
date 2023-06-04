using System.ComponentModel.DataAnnotations;

namespace ForekOnlineApplication.Models
{
    public class Enrolment
    {
        [Key]
        public Guid EnrolmentId { get; set; }
       

        //Relationship
        //public Guid StudentId { get; set; }
        //public Student Student { get; set; }
        
       

    }
}
