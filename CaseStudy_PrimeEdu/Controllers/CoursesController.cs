using CaseStudy_PrimeEdu.Data;
using CaseStudy_PrimeEdu.Data.Services;
using CaseStudy_PrimeEdu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;

namespace CaseStudy_PrimeEdu.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesService _service;

        public CoursesController(ICoursesService service)
        {
            _service = service;
        }

        //CREATE
        public async Task<IActionResult> Create()
        { 
            Course course = new Course();
            course.TeacherNames = await _service.GetAvailableTeachersList();
            return View(course);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Description, Location, CourseDuration, TeacherId")] Course course)
        {
            if (!ModelState.IsValid)
            {
                course.TeacherNames = await _service.GetAvailableTeachersList();                
                return View(course);
            }

            await _service.AddAsync(course);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddStudentToCourse(int id, int courseId)
        {
            await _service.AddStudentToCourse(id, courseId);
            return RedirectToAction(nameof(Students), new { id = courseId });
        }

        //READ 
        public async Task<IActionResult> Details(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return View("NotFound");
            return View(data);
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();

            //Teacher column service
            foreach (var item in data)
            {
                if (item.TeacherId > 0)
                {
                    item.TeacherName = await _service.GetCourseTeacherById(item.TeacherId);
                }
            }
            return View(data);
        }
        public async Task<IActionResult> Students(int id) //Index->Students(Grid Form)->AddStudent
        {
            var data = await _service.GetCourseStudents(id);
            ViewData["CourseId"] = id;
            return View(data);
        }
        public async Task<IActionResult> AddStudent(int id) //to course
        {
            var data = await _service.GetAllStudentsAsync(id);
            if (data == null) return View("NotFound");

            ViewData["CourseId"] = id;
            return View(data);
        }
        public async Task<IActionResult> Tests(int id) //Index->Tests(Grid Form)->AddStudent
        {
            var data = await _service.GetCourseTests(id);
            ViewData["CourseId"] = id;
            return View(data);
        }
        public async Task<IActionResult> TestResults(int id, int courseId)
        {
            var data = await _service.GetTestResultsAsync(id);
            if (data == null) return View("NotFound");

            ViewData["CourseId"] = courseId;
            return View(data);
        }

        //UPDATE
        public async Task<IActionResult> Edit(int id)
        {

            var data = await _service.GetByIdAsync(id);
            if (data == null) return View("NotFound");

            data.TeacherNames = await _service.GetAvailableTeachersList();
            ViewData["CourseId"] = id;
            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Description, Location, CourseDuration, TeacherId")] Course course)
        {
            if (!ModelState.IsValid)
            {
                return View(course);
            }

            await _service.UpdateAsync(id, course);

            return RedirectToAction(nameof(Index));
        }

        //DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteStudent(int id, int courseId)
        {
            await _service.DeleteCourseStudentAsync(id, courseId);

            return RedirectToAction(nameof(Students), new {id = courseId});
        }

        //TODO    
        public IActionResult Error()
        {
            return View();
        }
    }
}
