using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ForekOnlineApplication.Models
{
    public class SecondarySchool
    {
        [Key]
        public Guid HighSchoolId { get; set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }

        public string HighSchoolName { get; set; }
        public int GradePassed { get; set; }
    }
}
