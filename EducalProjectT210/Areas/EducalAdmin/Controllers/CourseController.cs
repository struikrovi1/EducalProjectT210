using EducalProjectT210.Helpers;
using EducalProjectT210.Models;
using Microsoft.AspNetCore.Mvc;

namespace EducalProjectT210.Areas.EducalAdmin.Controllers
{
    [Area(nameof(EducalAdmin))]
    public class CourseController : Controller
    {

        private readonly CourseDBContext _context;

        private readonly IWebHostEnvironment _enviro; //wwwroot

        public CourseController(CourseDBContext context, IWebHostEnvironment enviro)
        {
            _context = context;
            _enviro = enviro;
        }



        public IActionResult Index()
        {
            return View(_context.Course.ToList());
        }
        public IActionResult Create()
        {

            ViewBag.CategoryList = _context.Categories.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult Create(Course course, IFormFile PhotoUrl)
        {

            string photoName = PictureHelper.UploadPicture(PhotoUrl, _enviro);
            
            course.PhotoUrl = photoName;//sql s kakim imenem idet fotka

            _context.Course.Add(course);
            _context.SaveChanges();

            return RedirectToAction("index");
        }







        public IActionResult Edit(int? id)
        { if (id == null) return NotFound();
            ViewBag.CategoryList = _context.Categories.ToList();
            var selectedCourse = _context.Course.Find(id);
            if (selectedCourse == null) return NotFound();
            return View(selectedCourse);
        }

        [HttpPost]
        public IActionResult Edit(Course course, IFormFile PhotoUrl)
        {
            if (PhotoUrl != null)
            {
                string photoName = PictureHelper.UploadPicture(PhotoUrl, _enviro);

                course.PhotoUrl = photoName;//sql s kakim imenem idet fotka
            }

            _context.Course.Update(course);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var selectedCourse = _context.Course.Find(id);
            if (selectedCourse == null) return NotFound();
            _context.Course.Remove(selectedCourse);
            _context.SaveChanges();
            return RedirectToAction("index");


           
        }
    }
}
