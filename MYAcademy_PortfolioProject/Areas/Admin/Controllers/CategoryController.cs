using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly PortfolioContext _context;

        public CategoryController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Categories.Include(x => x.Projects).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _context.Categories.Add(category);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Kategori başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var value = _context.Categories.Find(id);

            if (value == null)
                return NotFound();

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            var value = _context.Categories.Find(category.CategoryId);
            if (value == null)
                return NotFound();

            value.CategoryName = category.CategoryName;
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Kategori başarıyla güncellendi.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.FirstOrDefault(x => x.CategoryId == id);

            _context.Categories.Remove(value);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Kategori başarıyla silindi.";
            return RedirectToAction("Index");
        }
    }
}
