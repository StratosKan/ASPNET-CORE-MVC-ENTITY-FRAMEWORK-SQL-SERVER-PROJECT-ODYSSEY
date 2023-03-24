using CaseStudy_PrimeEdu.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CaseStudy_PrimeEdu.Data.Services
{
    public class TeachersService: ITeachersService
    {
        private readonly AppDbContext _context;

        public TeachersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Teacher teacher)
        {
            //Extra Data
            teacher.FullName = String.Format(teacher.FirstName + " " + teacher.LastName);
            teacher.CreationDate = DateTime.Now;

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task<Teacher> GetByIdAsync(int id)
        {
            var result = await _context.Teachers.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            var result = await _context.Teachers.ToListAsync();
            return result;
        }

        public async Task<Teacher> UpdateAsync(int id, Teacher newTeacher)
        {
            newTeacher.FullName = String.Format(newTeacher.FirstName + " " + newTeacher.LastName);
            newTeacher.LastModifiedDate = DateTime.Now;

            var entityEntry = _context.Entry(newTeacher);

            // Update only the specified properties
            entityEntry.Property(e => e.Title).IsModified = true;
            entityEntry.Property(e => e.FullName).IsModified = true;
            entityEntry.Property(e => e.FirstName).IsModified = true;
            entityEntry.Property(e => e.LastName).IsModified = true;
            entityEntry.Property(e => e.Description).IsModified = true;
            entityEntry.Property(e => e.LastModifiedDate).IsModified = true;

            await _context.SaveChangesAsync();
            return newTeacher;
        }
        public async Task DeleteAsync(int id)
        {
            var result = await _context.Teachers.FirstOrDefaultAsync(n => n.Id == id);
            _context.Teachers.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}
