using EducalProjectT210.Models;
using EducalProjectT210.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducalProjectT210.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseDBContext _context;

        public CourseController(CourseDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id,string searchText)
        {
            //Hoffman,Samsung,Iphone,Lg
            var courses = _context.Course.Include(x => x.Category).AsQueryable();

            if (id !=null)
            {
                courses = courses.Where(x=>x.CategoryId==id);
            }
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                courses = courses.Where(c=>c.Name.Contains(searchText));
            }
            CourseIndexVM courseVM = new()
            {
                Courses= courses.ToList()
            };
            return View(courseVM);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            var courseInfo = _context.Course.Include(x=>x.Category).FirstOrDefault(x=>x.Id==id);

            if (courseInfo == null) return NotFound();
            var serifList = _context.Course.Include(x=>x.Category).Where(x => x.CategoryId == courseInfo.CategoryId && x.Id!=id).ToList();
        
            CourseDetailVM courseDetailVM = new()
            {
                SingleCourse = courseInfo,
                SameCourses=serifList
            };
            return View(courseDetailVM);
        }
    }
}
