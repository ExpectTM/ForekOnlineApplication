using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ForekOnlineApplication.Enums.Enums;

namespace ForekOnlineApplication.Models
{
    public class Person : Base
    {
        [Key]
        public Guid PersonId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "ID Number")]
        public string ApplicantId { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1900/01/01", "2006/12/31", ErrorMessage = "Invalid date of birth, You must be 16 years or older")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public eGender Gender { get; set; }
        [Required]
        public eRace Race { get; set; }
        [Required]
        public eTitle Title { get; set; }
        [Required]
        [Display(Name = "Other Nationaliy")]
        public eNationality Nationality { get; set; }

        [NotMapped]
        public IFormFile? IdDoc { get; set; }

        
        //public string? Description { get; set; }


        //Relationships
        //public Address? Address { get; set; }
        //public Contact? Contact { get; set; }
        //public Applicant? Applicant { get; set; }
        //public Guardian? Guardian { get; set; }

    }
}
