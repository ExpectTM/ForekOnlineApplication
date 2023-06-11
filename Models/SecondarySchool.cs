using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static ForekOnlineApplication.Enums.Enums;

namespace ForekOnlineApplication.Models
{
    public class SecondarySchool
    {
        [Key]
        public Guid HighSchoolId { get; set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }

        public string HighSchoolName { get; set; }
        public eGrade GradePassed { get; set; }

        [NotMapped]
        public IFormFile? MatricDoc { get; set; }
    }
}
