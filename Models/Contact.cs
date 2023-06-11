using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForekOnlineApplication.Models
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }

        

        [Required]
        public int Phone { get; set; }

        [Remote(action: "VerifyEmail", controller: "Contact")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        //Relationships

        //public Guid PersonId { get; set; }
        //public Person Person { get; set; }
      
        //public Guid MedicalId { get; set; }
        //public Medical Medical { get; set; }
        //public Guid? InstitutionId { get; set; }
        //public Institution Institution { get; set; }
    }
}
