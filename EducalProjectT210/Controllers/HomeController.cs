using EducalProjectT210.Models;
using EducalProjectT210.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EducalProjectT210.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CourseDBContext _context;

        public HomeController(ILogger<HomeController> logger, CourseDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() 
        {
            HomeVm vm = new()
            {
                Categories = _context.Categories.ToList(),
                ClassRooms = _context.ClassRooms.ToList(),
                Courses = _context.Course.ToList(),
                Slider = _context.Section1s.FirstOrDefault()
            };
            return View(vm);
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