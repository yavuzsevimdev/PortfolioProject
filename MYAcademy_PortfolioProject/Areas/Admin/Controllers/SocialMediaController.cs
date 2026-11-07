using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly PortfolioContext _context;

        public SocialMediaController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SocialMediaList()
        {
            var value = _context.SocialMedias.ToList();
            return View(value);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                return View(socialMedia);
            }
            _context.SocialMedias.Add(socialMedia);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                return View(socialMedia);
            }
            _context.SocialMedias.Update(socialMedia);
            _context.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var value = _context.SocialMedias.Find(id);
            if (value != null)
            {
                _context.SocialMedias.Remove(value);
                _context.SaveChanges();
            }
            return RedirectToAction("SocialMediaList");
        }
    }
}
