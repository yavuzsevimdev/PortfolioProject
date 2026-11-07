using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {
        private readonly PortfolioContext _context;

        public ExperienceController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ExperienceList()
        {
            var values = _context.Experiences.ToList();
            return View(values);
        }


        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return View(experience);
            }

            _context.Experiences.Add(experience);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Deneyim bilgisi başarıyla eklendi.";
            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var experience = _context.Experiences.Find(id);
            return View(experience);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return View(experience);
            }

            _context.Experiences.Update(experience);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Deneyim bilgisi başarıyla güncellendi.";
            return RedirectToAction("ExperienceList");
        }

        public IActionResult DeleteExperience(int id)
        {
            var experience = _context.Experiences.Find(id);
            if (experience != null)
            {
                _context.Experiences.Remove(experience);
                _context.SaveChanges();
            }

            TempData["SuccessMessage"] = "Deneyim bilgisi başarıyla silindi.";
            return RedirectToAction("ExperienceList");
        }
    }
}
