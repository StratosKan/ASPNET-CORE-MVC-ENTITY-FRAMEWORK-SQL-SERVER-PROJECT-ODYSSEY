using CaseStudy_PrimeEdu.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy_PrimeEdu.Data.Services
{
    public class TestsService: ITestsService
    {
        private readonly AppDbContext _context;

        public TestsService(AppDbContext context)
        {
            _context = context;
        }

        //CREATE
        public async Task AddAsync(Test test)
        {
            //Extra Data
            Random rnd = new Random();
            test.Grade = rnd.Next(1,101);
            if (test.Grade > 50){test.Result = true;} else {test.Result = true;}
            
            test.CreationDate = DateTime.Now;

            await _context.Tests.AddAsync(test);
            await _context.SaveChangesAsync();

            CoursesService coursService = new CoursesService(_context);
            await coursService.AddTestToCourse(test.CourseId, test.Id);
        }

        //READ
        public async Task<Test> GetByIdAsync(int id)
        {
            var result = await _context.Tests.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<IEnumerable<Test>> GetAllAsync()
        {
            var result = await _context.Tests.ToListAsync();
            return result;
        }
        public async Task<List<Course>> GetAvailableCoursesList()
        {
            var result = await _context.Courses.ToListAsync();
            return result;
        }

        //UPDATE
        public async Task<Test> UpdateAsync(int id, Test newTest)
        {
            newTest.LastModifiedDate = DateTime.Now;

            var entityEntry = _context.Entry(newTest);

            // Update only the specified properties
            entityEntry.Property(e => e.Name).IsModified = true;
            entityEntry.Property(e => e.Description).IsModified = true;
            entityEntry.Property(e => e.CourseId).IsModified = true;
            entityEntry.Property(e => e.LastModifiedDate).IsModified = true;

            await _context.SaveChangesAsync();
            return newTest;
        }

        //DELETE
        public async Task DeleteAsync(int id)
        {
            var result = await _context.Tests.FirstOrDefaultAsync(n => n.Id == id);
            _context.Tests.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}
