using CaseStudy_PrimeEdu.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy_PrimeEdu.Data.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly AppDbContext _context;

        public StudentsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Student student)
        {
            //Extra Data
            student.FullName = String.Format(student.FirstName + " " + student.LastName);
            student.CreationDate = DateTime.Now;

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }
                
        public async Task<Student> GetByIdAsync(int id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(n => n.Id == id);            
            return result;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var result =  await _context.Students.ToListAsync();
            return result;
        }

        public async Task<Student> UpdateAsync(int id, Student newStudent)
        {
            newStudent.FullName = String.Format(newStudent.FirstName + " " + newStudent.LastName);
            newStudent.LastModifiedDate = DateTime.Now;

            var entityEntry = _context.Entry(newStudent);

            // Update only the specified properties
            entityEntry.Property(e => e.FullName).IsModified = true;
            entityEntry.Property(e => e.FirstName).IsModified = true;
            entityEntry.Property(e => e.LastName).IsModified = true;
            entityEntry.Property(e => e.Description).IsModified = true;
            entityEntry.Property(e => e.LastModifiedDate).IsModified = true;

            await _context.SaveChangesAsync();
            return newStudent;
        }
        public async Task DeleteAsync(int id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(n => n.Id == id);
            _context.Students.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}
