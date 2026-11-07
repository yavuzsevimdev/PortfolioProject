using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly PortfolioContext _context;

        public EducationController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult EducationList()
        {
            var value = _context.Educations.ToList();
            return View(value);
        }

        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEducation(Education about)
        {
            if (!ModelState.IsValid)
            {
                return View(about);
            }
            _context.Educations.Add(about);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Eğitim bilgisi başarıyla eklendi.";
            return RedirectToAction("EducationList");
        }

        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            var about = _context.Educations.Find(id);
            return View(about);
        }

        [HttpPost]
        public IActionResult UpdateEducation(Education about)
        {
            if (!ModelState.IsValid)
            {
                return View(about);
            }

            _context.Educations.Update(about);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Eğitim bilgisi başarıyla güncellendi.";
            return RedirectToAction("EducationList");
        }

        public IActionResult DeleteEducation(int id)
        {
            var about = _context.Educations.Find(id);
            if (about != null)
            {
                _context.Educations.Remove(about);
                _context.SaveChanges();
            }

            TempData["SuccessMessage"] = "Eğitim bilgisi başarıyla silindi.";
            return RedirectToAction("EducationList");
        }
    }
}
