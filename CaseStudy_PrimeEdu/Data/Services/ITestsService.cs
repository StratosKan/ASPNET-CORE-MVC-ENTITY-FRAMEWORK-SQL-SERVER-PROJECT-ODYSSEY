using CaseStudy_PrimeEdu.Models;

namespace CaseStudy_PrimeEdu.Data.Services
{
    public interface ITestsService
    {
        Task<IEnumerable<Test>> GetAllAsync();
        Task<Test> GetByIdAsync(int id);
        Task<List<Course>> GetAvailableCoursesList();
        Task AddAsync(Test test);
        Task<Test> UpdateAsync(int id, Test newTest);
        Task DeleteAsync(int id);

        //TODO: Implement multi-installation logic
    }
}
