using System.ComponentModel.DataAnnotations;
using static ForekOnlineApplication.Enums.Enums;

namespace ForekOnlineApplication.Models
{
    public class Person : Base
    {
        [Key]
        public Guid PersonId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public string DateOfBirth { get; set; }

        public eGender Gender { get; set; }

        public eRace Race { get; set; }

        public eTitle Title { get; set; }

        [Display(Name = "Other Nationaliy")]
        public eNationality Nationality { get; set; }

       
        //public string? Description { get; set; }


        //Relationships
        //public Address? Address { get; set; }
        //public Contact? Contact { get; set; }
        //public Applicant? Applicant { get; set; }
        //public Guardian? Guardian { get; set; }

    }
}
