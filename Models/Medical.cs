using System.ComponentModel.DataAnnotations;

namespace ForekOnlineApplication.Models
{
    public class Medical
    {
        [Key]
        public Guid? MedicalId { get; set; }
        public string MedicalName { get; set;}
        public string MedicalDescription { get; set;}

        //Relationships
        
        //public Address Address { get; set;}
        
        //public Student Student { get; set;}

    }
}
