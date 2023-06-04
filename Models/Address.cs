using System.ComponentModel.DataAnnotations;
using static ForekOnlineApplication.Enums.Enums;

namespace ForekOnlineApplication.Models
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }

        [Display(Name = "Unit / House / Complex Number")]
        public string? AddressLine1 { get; set; }

        [Display(Name = "Surburb / City")]
        public string? AddressLine2 { get; set; }


        [Display(Name = "Is The Same ?")]
        public bool isSame { get; set; }


        [Display(Name = "Postal Code")]
        [MaxLength(4)]
        [StringLength(4)]
        public string? PostalCode { get; set; }

        [Display(Name = "Unit / House / Complex Number")]
        public string? PostalAddressLine1 { get; set; }

        [Display(Name = "Surburb / City")]
        public string? PostalAddressLine2 { get; set; }

        public eProvince? Province { get; set; }
        public eCountry? Country { get; set; }

        public eProvince? Province1 { get; set; }
        public eCountry? Country1 { get; set; }


        //Relationships
        //public Guid PersonId { get; set; }
        //public Person? Person { get; set; }
        //public Medical? Medical { get; set; }
        //public Guid? MedicalId { get; set; }
        //public Guid? InstitutionId { get; set; }
        //public Institution? Institution { get; set; }
    }
}
