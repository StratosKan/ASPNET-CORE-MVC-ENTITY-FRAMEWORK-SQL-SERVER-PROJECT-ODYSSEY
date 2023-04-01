using CaseStudy_PrimeEdu.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CaseStudy_PrimeEdu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // set a cookie
            HttpContext.Response.Cookies.Append("cookieName", "cookieValue", new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddHours(1),
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict
            });

            // read a cookie
            var cookieValue = HttpContext.Request.Cookies["cookieName"];


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}