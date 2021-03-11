//tinfo200:[2021-03-03-sotoe-dykstra1] - inherits from DbContext and creates a DbSet property for each corresponding database table


using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }
        //tinfo200:[2021-03-03-sotoe-dykstra1] - creates three entities to be used in the database table
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        //tinfo200:[2021-03-03-sotoe-dykstra1] - method that overrides default table names into a singular form instead
        // of being pluralized in the DbContext
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}
