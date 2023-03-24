using CaseStudy_PrimeEdu.Models;

namespace CaseStudy_PrimeEdu.Data.Services
{
    public interface ICoursesService
    {
        //READ
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        Task<List<Teacher>> GetAvailableTeachersList();
        Task<String> GetCourseTeacherById(int id);
        Task<List<Student>> GetCourseStudents(int courseId);
        Task<IEnumerable<Student>> GetAllStudentsAsync(int courseId);
        Task<List<Test>> GetCourseTests(int courseId);
        Task<Test> GetTestResultsAsync(int testId);

        //CREATE
        Task AddAsync(Course course);
        Task AddStudentToCourse(int studentId, int courseId);
        Task AddTestToCourse(int courseId, int testId);

        //UPDATE
        Task<Course> UpdateAsync(int id, Course course);

        //DELETE
        Task DeleteAsync(int id);
        Task DeleteCourseStudentAsync(int id, int courseId);
       

        //TODO: Implement multi-installation logic
    }
}
