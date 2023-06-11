using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks.Dataflow;
using static ForekOnlineApplication.Enums.Enums;

namespace ForekOnlineApplication.Models
{
    public class Applications
    {
        [Key]
        public Guid ApplicationsId { get; set; }

        [ForeignKey("Person")]
        public Guid PersenId { get; set; }

        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CourseType { get; set; }
        public string NQL { get; set; }
        public string Modules { get; set; }
    }
}
