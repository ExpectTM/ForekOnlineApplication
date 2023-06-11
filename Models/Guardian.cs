using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ForekOnlineApplication.Enums.Enums;

namespace ForekOnlineApplication.Models
{
    public class Guardian
    {
        [Key] 
        public Guid GuardianId { get; set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public eRelationship? Relationship { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }

        [NotMapped]
        public IFormFile? IdDoc { get; set; }

        //Relationships
        //public Guid PersonId { get; set; }
        //public Person Person { get; set; }


    }
}
