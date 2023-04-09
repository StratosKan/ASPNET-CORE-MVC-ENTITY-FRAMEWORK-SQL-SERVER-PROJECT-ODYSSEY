using CaseStudy_PrimeEdu.Data.Static;
using CaseStudy_PrimeEdu.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

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

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.Teacher))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Teacher));
                if (!await roleManager.RoleExistsAsync(UserRoles.Student))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Student));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@school.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        FullName = "DEFAULT ADMIN", //TBD SUPER-USER
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                        InstallationId = 0
                    };

                    var result = await userManager.CreateAsync(newAdminUser, "admiN123!");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                    }
                }

                string appTeacherEmail = "teacher@school.com";

                var appTeacher = await userManager.FindByEmailAsync(appTeacherEmail);
                if (appTeacher == null)
                {
                    var newAppTeacher = new ApplicationUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        FullName = "DEFAULT TEACHER",
                        UserName = "teacher",
                        Email = appTeacherEmail,
                        EmailConfirmed = true,
                        InstallationId = 0
                    };
                    var result = await userManager.CreateAsync(newAppTeacher, "teacheR123!");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newAppTeacher, UserRoles.Teacher);
                    }                    
                }

                string appStudentEmail = "student@school.com";

                var appStudent = await userManager.FindByEmailAsync(appStudentEmail);
                if (appStudent == null)
                {
                    var newAppStudent = new ApplicationUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        FullName = "DEFAULT STUDENT",
                        UserName = "student",
                        Email = appStudentEmail,
                        EmailConfirmed = true,
                        InstallationId = 0
                    };
                    var result = await userManager.CreateAsync(newAppStudent, "studenT123!");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newAppStudent, UserRoles.Student);
                    }                    
                }

                string appUserEmail = "user@school.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        Id = Guid.NewGuid().ToString(),
                        FullName = "DEFAULT USER",
                        UserName = "user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                        InstallationId = 0
                    };
                    var result = await userManager.CreateAsync(newAppUser, "useR123!");
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                    }                    
                }
            }
        }
    }
}
