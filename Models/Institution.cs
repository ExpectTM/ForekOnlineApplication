using System.ComponentModel.DataAnnotations;

namespace ForekOnlineApplication.Models
{
    public class Institution
    {
        [Key]
        public Guid? InstitutionId { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? InstitutionName { get; set; }
        public string? InstitutionDescription { get; set;}

        //Relationships
        
        //public Applicant Applicant { get; set; }
      
        //public Address Address { get; set; }
       
        //public Contact Contact { get; set; }

    }
}
