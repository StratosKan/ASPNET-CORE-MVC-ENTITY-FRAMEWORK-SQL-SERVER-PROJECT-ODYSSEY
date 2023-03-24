using CaseStudy_PrimeEdu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using CaseStudy_PrimeEdu.Data.Services;

namespace CaseStudy_PrimeEdu.Data.Services
{
    public class CoursesService: ICoursesService
    {
        private readonly AppDbContext _context;

        public CoursesService(AppDbContext context)
        {
            _context = context;
        }

        //CREATE
        public async Task AddAsync(Course course)
        {
            //Extra Data
            course.StartDate = DateTime.Now;
            course.CreationDate = DateTime.Now;

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }
        public async Task AddStudentToCourse(int studentId, int courseId) //todo: <T>
        {
            var result = await _context.Course_Students.Where(n => n.StudentId == studentId).Where(n => n.CourseId == courseId).FirstOrDefaultAsync();
            if (result == null)
            {
                var courseStudent = new Course_Student { CourseId = courseId, StudentId = studentId };

                await _context.Set<Course_Student>().AddAsync(courseStudent);
                await _context.SaveChangesAsync();
            }
        }
        public async Task AddTestToCourse(int courseId, int testId)
        {
            //var result = await _context.Course_Students.Where(n => n.StudentId == id).Where(n => n.CourseId == courseId).FirstOrDefaultAsync();
            var courseTest = new Course_Test {CourseId = courseId, TestId = testId };
            
            await _context.Set<Course_Test>().AddAsync(courseTest);
            await _context.SaveChangesAsync();
        }

        //READ
        public async Task<Course> GetByIdAsync(int id)
        {
            var result = await _context.Courses.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var result = await _context.Courses.ToListAsync();
            return result;
        }
        public async Task<List<Teacher>> GetAvailableTeachersList()
        {
            var result = await _context.Teachers.ToListAsync();
            return result;
        }
        public async Task<String> GetCourseTeacherById(int id)
        {
            var teacher = await _context.Teachers.Where(o => o.Id == id).FirstOrDefaultAsync();

            string returnTeacherName = string.Empty;
            if (teacher != null)
            {
                if (!String.IsNullOrEmpty(teacher.FullName))
                {
                    returnTeacherName = teacher.FullName;
                };
            }            
            return returnTeacherName;
        }
        public async Task<List<Student>> GetCourseStudents(int courseId)
        {
            //this is how an inner join looks nowadays...
            var courseStudents = await _context.Course_Students.Where(cs => cs.CourseId == courseId).ToListAsync();

            List<Student> students = new List<Student>();
            if (courseStudents.Count > 0)
            {
                foreach (var student in courseStudents)
                {
                    var studentId = student.StudentId;
                    var studentEntity = _context.Students.Where(o => o.Id == studentId).FirstOrDefault();
                    if (studentEntity != null) {
                        studentEntity.activeCourseId = courseId;
                        students.Add(studentEntity); 
                    } //todo: if not found then remove course_students entry
                }
            }
            return students;
        }
        public async Task<IEnumerable<Student>> GetAllStudentsAsync(int courseId)
        {
            StudentsService studService = new StudentsService(_context);
            var result = await studService.GetAllAsync();
            foreach (var student in result)
            {
                student.activeCourseId = courseId;
            }
            return result;
        }
        public async Task<List<Test>> GetCourseTests(int courseId)
        {
            var courseTests = await _context.Course_Tests.Where(cs => cs.CourseId == courseId).ToListAsync();

            List<Test> tests = new List<Test>();
            if (courseTests.Count > 0)
            {
                foreach (var test in courseTests)
                {
                    var testId = test.TestId;
                    var testEntity = _context.Tests.Where(o => o.Id == testId).FirstOrDefault();
                    if (testEntity != null)
                    {
                        tests.Add(testEntity);
                    } //todo: if not found then remove course_tests entry
                }
            }
            return tests;
        }
        public async Task<Test> GetTestResultsAsync(int testId)
        {
            var testEntity = await _context.Tests.Where(o => o.Id == testId).FirstOrDefaultAsync();
            return testEntity;
        }

        //UPDATE
        public async Task<Course> UpdateAsync(int id, Course newCourse)
        {
            newCourse.LastModifiedDate = DateTime.Now;

            var entityEntry = _context.Entry(newCourse);

            // Update only the specified properties
            entityEntry.Property(e => e.Name).IsModified = true;
            entityEntry.Property(e => e.Location).IsModified = true;
            entityEntry.Property(e => e.CourseDuration).IsModified = true;
            entityEntry.Property(e => e.Description).IsModified = true;
            entityEntry.Property(e => e.TeacherId).IsModified = true;
            entityEntry.Property(e => e.LastModifiedDate).IsModified = true;

            await _context.SaveChangesAsync();
            return newCourse;
        }

        //DELETE
        public async Task DeleteAsync(int id)
        {
            var atLeastOne = await _context.Courses.FirstOrDefaultAsync();
            if (atLeastOne == null){ return;}

            var result = await _context.Courses.FirstOrDefaultAsync(n => n.Id == id);
            _context.Courses.Remove(result);

            await DeleteJoinsAsync(id);

            await _context.SaveChangesAsync();
        }

        private async Task DeleteJoinsAsync(int id)
        {
            //Course>Students

            var joinStudents = await _context.Course_Students.Where(n => n.CourseId == id).ToListAsync();
            
            foreach(var student in joinStudents)
            {
                _context.Course_Students.Remove(student);
            }

            //Course>Tests

            var joinTests = await _context.Course_Tests.Where(n => n.CourseId == id).ToListAsync();

            foreach (var test in joinTests)
            {
                _context.Course_Tests.Remove(test);
            }
        }

        public async Task DeleteCourseStudentAsync(int id, int courseId)
        {
            var result = await _context.Course_Students.Where(n => n.StudentId == id).Where(n => n.CourseId == courseId).FirstOrDefaultAsync();
            _context.Course_Students.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}
