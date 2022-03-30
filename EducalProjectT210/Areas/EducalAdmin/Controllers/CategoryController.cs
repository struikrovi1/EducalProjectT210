using EducalProjectT210.Models;
using Microsoft.AspNetCore.Mvc;

namespace EducalProjectT210.Areas.EducalAdmin.Controllers
{
    [Area(nameof(EducalAdmin))]
    public class CategoryController : Controller
    {
        private readonly CourseDBContext _context;

        public CategoryController(CourseDBContext context)  
        {
            _context = context;
        }

        public IActionResult Index()//read
        { 
            return View(_context.Categories.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category newCategory)
        {
            _context.Categories.Add(newCategory);
            _context.SaveChanges(); 
            return RedirectToAction(nameof(Index),"Category", new { area = nameof(EducalAdmin) });
        }


        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var category = _context.Categories.FirstOrDefault(x=>x.CategoryId == id);   
            return View(category);
        }


        [HttpPost]
        public IActionResult Edit(Category oldCategory)
        {
            _context.Categories.Update(oldCategory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Category", new { area = nameof(EducalAdmin) });
        }


        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index), "Category", new { area = nameof(EducalAdmin) });
        }

    }
}
