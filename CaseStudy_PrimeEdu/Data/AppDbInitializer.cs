using CaseStudy_PrimeEdu.Models;

namespace CaseStudy_PrimeEdu.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //User
                if (!context.ApplicationUsers.Any())
                {
                    context.ApplicationUsers.AddRange(new List<ApplicationUser>()
                    {
                        new ApplicationUser()
                        {
                           UserName = "admin",
                           InstallationId = 1
                           //Password = "123"
                        },
                        new ApplicationUser()
                        {
                            UserName = "student",
                            InstallationId = 1
                            //Password = "123"
                        },
                        new ApplicationUser()
                        {
                            UserName = "teacher",
                            InstallationId = 1
                            //Password = "123"
                        }
                    });

                    context.SaveChanges();
                }
                //Course
                if (!context.Courses.Any())
                {

                }
                //Teacher
                if (!context.Teachers.Any())
                {
                    context.Teachers.AddRange(new List<Teacher>()
                    {
                        new Teacher()
                        {
                            InstallationId = 1,
                            FirstName = "Leonardo",
                            LastName = "DaVinci",
                            FullName = "Leonardo DaVinci",
                            Description = "15th century polymath",
                            Title = "Engineer",
                            CreationDate = DateTime.Now
                        },
                        new Teacher()
                        {
                            InstallationId = 2,
                            FirstName = "DEFAULT",
                            LastName = "TEACHER",
                            FullName = "DEFAULT TEACHER",
                            Description = "Daily Lessons",
                            Title = "Physics Teacher",
                            CreationDate= DateTime.Now
                        }
                    });

                    context.SaveChanges();                   
                }
                //Student
                if (!context.Students.Any())
                {
                    context.Students.AddRange(new List<Student>()
                    {
                        new Student()
                        {
                           InstallationId = 1,
                           FirstName = "John",
                           LastName = "Doe",
                           FullName = "John Doe",
                           CreationDate = DateTime.Now,
                           Description = "12345"
                        },
                        new Student()
                        {
                           InstallationId = 2,
                           FirstName = "DEFAULT",
                           LastName = "STUDENT",
                           FullName = "DEFAULT STUDENT",
                           CreationDate = DateTime.Now,
                           Description = "---------"
                        },
                        new Student()
                        {
                            InstallationId = 1,
                            FirstName = "Lady",
                            LastName = "Gaga",
                            FullName = "Lady Gaga",
                            CreationDate = DateTime.Now,
                            Description = "Singer"
                        },
                        new Student()
                        {
                            InstallationId = 1,
                            FirstName = "Peter",
                            LastName = "B",
                            FullName = "Peter B",
                            CreationDate = DateTime.Now,
                            Description = ""
                        }
                    });
                    
                    context.SaveChanges();
                }
                //Test
                if (!context.Tests.Any())
                {

                }
                //Course-Student
                if (!context.Course_Students.Any())
                {

                }
                //Course-Test
                if (!context.Course_Tests.Any())
                {

                }
            }
        }
    }
}
