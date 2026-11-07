using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SkillList()
        {
            var values = _context.Skills.Include(x => x.SkillItems).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            if(!ModelState.IsValid)
            {
                return View(skill);
            }

            _context.Skills.Add(skill);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Yetenek bilgisi başarıyla eklendi.";
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var value = _context.Skills.Include(x => x.SkillItems).FirstOrDefault(x => x.SkillId == id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
            {
                return View(skill);
            }

            _context.Skills.Update(skill);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Yetenek bilgisi başarıyla güncellendi.";
            return RedirectToAction("SkillList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSkill(int id)
        {
            var skill = _context.Skills.Find(id);

            if (skill == null)
            {
                TempData["ErrorMessage"] = "Yetenek kaydı bulunamadı.";
                return RedirectToAction("SkillList");
            }

            _context.Skills.Remove(skill);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Yetenek başarıyla silindi.";

            return RedirectToAction("SkillList");
        }
    }   
}
