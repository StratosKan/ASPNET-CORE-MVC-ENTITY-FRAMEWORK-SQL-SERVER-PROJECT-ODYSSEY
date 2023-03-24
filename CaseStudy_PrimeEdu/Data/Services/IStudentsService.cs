using CaseStudy_PrimeEdu.Models;

namespace CaseStudy_PrimeEdu.Data.Services
{
    public interface IStudentsService
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(int id);
        Task AddAsync(Student student);
        Task<Student> UpdateAsync(int id, Student newStudent);
        Task DeleteAsync(int id);

        //TODO: Implement multi-installation logic
    }
}
