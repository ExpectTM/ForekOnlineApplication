using System.ComponentModel.DataAnnotations;

namespace ForekOnlineApplication.Models
{
    public class Department
    {
        [Key]
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set;}
        public string DepartmentType { get; set; }

        //Relationship
        //public Guid CourseId { get; set; }
        //public ICollection<Course> Courses { get; set; }
    }
}
