using System.ComponentModel.DataAnnotations;

namespace ForekOnlineApplication.Models
{
    public class Payment
    {
        [Key]
        public Guid PaymentId { get; set; }
        public string PaymentType { get; set; }
        public double PaymentAmount { get; set; }
        public string PaymentDescription { get; set; }

        //Relationship
        //public Guid CourseId { get; set; }
        //public Course Course { get; set; }
        

        
    }
}
