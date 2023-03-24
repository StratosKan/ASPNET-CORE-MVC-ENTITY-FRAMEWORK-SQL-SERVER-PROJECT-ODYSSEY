using CaseStudy_PrimeEdu.Data;
using CaseStudy_PrimeEdu.Data.Services;
using CaseStudy_PrimeEdu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy_PrimeEdu.Controllers
{
    public class TestsController : Controller
    {
        private readonly ITestsService _service;

        public TestsController(ITestsService service)
        {
            _service = service;
        }

        //CREATE
        public async Task<IActionResult> Create()
        {
            Test test = new Test();
            test.CourseList = await _service.GetAvailableCoursesList();
            return View(test);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name, Description, CourseId")] Test test)
        {
            if (!ModelState.IsValid)
            {
                test.CourseList = await _service.GetAvailableCoursesList();
                return View(test);
            }

            await _service.AddAsync(test);

            return RedirectToAction(nameof(Index));
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
            return View(data);
        }

        //EDIT
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Description, CourseId")] Test test)
        {
            if (!ModelState.IsValid)
            {
                return View(test);
            }

            await _service.UpdateAsync(id, test);

            return RedirectToAction(nameof(Index));
        }

        //DELETE
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return View("NotFound");

            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
