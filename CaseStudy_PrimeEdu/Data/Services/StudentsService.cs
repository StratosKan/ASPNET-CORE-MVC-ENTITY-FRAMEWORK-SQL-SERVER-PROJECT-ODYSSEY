using CaseStudy_PrimeEdu.Data.Base;
using CaseStudy_PrimeEdu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CaseStudy_PrimeEdu.Data.Services
{
    public class StudentsService : EntityBaseRepository<Student>, IStudentsService
    {
        public StudentsService(AppDbContext context) : base(context) { }

        public override async Task AddAsync(Student student)
        {
            //Extra Data
            student.FullName = String.Format(student.FirstName + " " + student.LastName);
            student.CreationDate = DateTime.Now;

            await base.AddAsync(student);
        }

        public override async Task UpdateAsync(int id, Student newStudent)
        {
            newStudent.FullName = String.Format(newStudent.FirstName + " " + newStudent.LastName);
            newStudent.LastModifiedDate = DateTime.Now;

            // Update only the specified properties
            List<string> propertiesToUpdate = new List<string>
            {            
             "FullName",
             "FirstName",
             "LastName",
             "Description",
             "LastModifiedDate"
            };

            await base.UpdatePartialAsync(id, newStudent, propertiesToUpdate);                        
        }
    }
}
