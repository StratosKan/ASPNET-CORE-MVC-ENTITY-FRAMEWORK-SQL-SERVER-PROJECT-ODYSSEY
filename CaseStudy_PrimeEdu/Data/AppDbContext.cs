using CaseStudy_PrimeEdu.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy_PrimeEdu.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Course_Student
            modelBuilder.Entity<Course_Student>().HasKey(cs => new
            {
                cs.CourseId,
                cs.StudentId
            });

            modelBuilder.Entity<Course_Student>().HasOne(c => c.Course).WithMany(cs =>cs.Course_Students).HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<Course_Student>().HasOne(c => c.Student).WithMany(cs => cs.Course_Students).HasForeignKey(c => c.StudentId);
            
            //Course_Test
            modelBuilder.Entity<Course_Test>().HasKey(ct => new
            {
                ct.CourseId,
                ct.TestId
            });

            modelBuilder.Entity<Course_Test>().HasOne(c => c.Course).WithMany(ct => ct.Course_Tests).HasForeignKey(c => c.CourseId);

            modelBuilder.Entity<Course_Test>().HasOne(c => c.Test).WithMany(ct => ct.Course_Tests).HasForeignKey(c => c.TestId);

            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set;}

        public DbSet<Course_Student> Course_Students { get; set; }
        public DbSet<Course_Test> Course_Tests { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Test> Tests { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
