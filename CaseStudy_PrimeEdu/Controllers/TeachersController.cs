using CaseStudy_PrimeEdu.Data;
using CaseStudy_PrimeEdu.Data.Services;
using CaseStudy_PrimeEdu.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy_PrimeEdu.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeachersService _service;

        public TeachersController(ITeachersService service)
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
        public async Task<IActionResult> Create([Bind("FirstName, LastName, Title, Description")] Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }

            await _service.AddAsync(teacher);

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
        public async Task<IActionResult> Edit(int id, [Bind("Id, FirstName, LastName, Title, Description")] Teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return View(teacher);
            }
                        
            await _service.UpdateAsync(id, teacher);

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
