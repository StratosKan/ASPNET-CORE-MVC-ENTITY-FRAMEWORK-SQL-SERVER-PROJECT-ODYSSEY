using CaseStudy_PrimeEdu.Models;

namespace CaseStudy_PrimeEdu.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task UpdatePartialAsync(int id, T entity, List<string> propertiesToUpdate);
        Task DeleteAsync(int id);
    }
}
