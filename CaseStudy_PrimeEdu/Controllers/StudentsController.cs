using CaseStudy_PrimeEdu.Data;
using CaseStudy_PrimeEdu.Data.Services;
using CaseStudy_PrimeEdu.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy_PrimeEdu.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService _service;

        public StudentsController (IStudentsService service)
        {
            _service = service;
        }

        //CREATE
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName, LastName, Description")]Student student)
        {
            if(!ModelState.IsValid)
            {
                return View(student);
            }

            await _service.AddAsync(student);

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
        public async Task<IActionResult> Edit(int id, [Bind("Id, FirstName, LastName, Description")] Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            await _service.UpdateAsync(id, student);

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

        //TODO    
        public IActionResult Error()
        {
            return View();
        }       

    }
}
