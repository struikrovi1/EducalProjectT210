using EducalProjectT210.Areas.EducalAdmin.ViewModels;
using EducalProjectT210.Models;
using Microsoft.AspNetCore.Mvc;

namespace EducalProjectT210.Areas.EducalAdmin.Controllers
{
    [Area("EducalAdmin")]
    public class DashboardController : Controller
    {


        private readonly CourseDBContext _context;

        public DashboardController(CourseDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {


            DashboardVM vm = new()
            {
                CourseCount=_context.Course.Count()
            }; 
            return View(vm);
        }
    }
}
