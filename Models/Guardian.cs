using System.ComponentModel.DataAnnotations;
using static ForekOnlineApplication.Enums.Enums;

namespace ForekOnlineApplication.Models
{
    public class Guardian
    {
        [Key] 
        public Guid GuardianId { get; set; }

        public eRelationship? Relationship { get; set; }

        //Relationships
        //public Guid PersonId { get; set; }
        //public Person Person { get; set; }
       

    }
}
