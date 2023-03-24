using CaseStudy_PrimeEdu.Models;

namespace CaseStudy_PrimeEdu.Data.Services
{
    public interface ITeachersService
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        Task AddAsync(Teacher teacher);
        Task<Teacher> UpdateAsync(int id, Teacher teacher);
        Task DeleteAsync(int id);

        //TODO: Implement multi-installation logic
    }
}
