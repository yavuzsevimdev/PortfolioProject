using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillItemController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillItemController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult SkillItemList(int skillId)
        {
            var values = _context.SkillItems.Where(x => x.SkillId == skillId).ToList();
            ViewBag.SkillId = skillId;

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateSkillItem(int skillId)
        {
            ViewBag.SkillId = skillId;
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkillItem(SkillItem skillItem)
        {
            if(!ModelState.IsValid)
            {
                return View(skillItem);
            }
            _context.SkillItems.Add(skillItem);
            _context.SaveChanges();

            return RedirectToAction("Index", new { skillId = skillItem.SkillId });
        }

        public IActionResult DeleteSkillItem(int id)
        {
            var value = _context.SkillItems.Find(id);
            if (value == null)
                return NotFound();
            int skillId = value.SkillId;
            _context.SkillItems.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index", new { skillId });
        }
    }
}
