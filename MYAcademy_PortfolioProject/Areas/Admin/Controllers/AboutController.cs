using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;

        public AboutController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult AboutList()
        {
            var value = _context.Abouts.FirstOrDefault();
            return View(value);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAbout(About about)
        {
            if(!ModelState.IsValid)
            {
                return View(about);
            }
            _context.Abouts.Add(about);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Hakkında bilgisi başarıyla eklendi.";
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var about = _context.Abouts.Find(id);
            return View(about);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            if (!ModelState.IsValid)
            {
                return View(about);
            }

            _context.Abouts.Update(about);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Hakkında bilgisi başarıyla güncellendi.";
            return RedirectToAction("AboutList");
        }

        public IActionResult DeleteAbout(int id)
        {
            var about = _context.Abouts.Find(id);
            if (about != null)
            {
                _context.Abouts.Remove(about);
                _context.SaveChanges();
            }

            TempData["SuccessMessage"] = "Hakkında bilgisi başarıyla silindi.";
            return RedirectToAction("AboutList");
        }
    }
}
