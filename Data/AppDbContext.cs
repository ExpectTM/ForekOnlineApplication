using ForekOnlineApplication.Models;
using Microsoft.EntityFrameworkCore;


namespace ForekOnlineApplication.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<HighSchool> HighSchools { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Medical> Medicals { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }

        
    }
}
