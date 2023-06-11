using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ForekOnlineApplication.Enums.Enums;

namespace ForekOnlineApplication.Models
{
    public class Qualification
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
 
        public string QualificationName { get; set; }
        public string QualificationDescription { get; set; }
        public string QualificationType { get; set; }
        public elevel Level { get; set; }

        [NotMapped]
        public IFormFile? CertificateDoc { get; set; }
    }
}
