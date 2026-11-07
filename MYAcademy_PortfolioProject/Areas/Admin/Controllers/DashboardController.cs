using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Areas.Admin.Models;
using MYAcademy_PortfolioProject.Context;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly PortfolioContext _context;

        public DashboardController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var totalProjectCount = _context.Projects.Count();
            var activeProjectCount = _context.Projects.Count(p => p.IsActive);
            var skillCount = _context.Skills.Count();
            var experienceCount = _context.Experiences.Count();
            var educationCount = _context.Educations.Count();
            var totalMessageCount = _context.Messages.Count();
            var totalUnreadMessageCount = _context.Messages.Count(m => !m.IsRead);

            var lastFiveMessages = _context.Messages.OrderByDescending(m => m.SendDate).Take(5).ToList();

            var categories = _context.Categories.Include(c => c.Projects).ToList();

            var lastThreeProjects = _context.Projects.Include(p => p.Category).OrderByDescending(p => p.CreatedDate).Take(3).ToList();

            var viewModel = new DashboardViewModel
            {
                TotalProjectCount = totalProjectCount,
                ActiveProjectCount = activeProjectCount,
                SkillCount = skillCount,
                ExperienceCount = experienceCount,
                EducationCount = educationCount,
                TotalMessageCount = totalMessageCount,
                TotalUnreadMessageCount = totalUnreadMessageCount,
                LastFiveMessages = lastFiveMessages,
                Categories = categories,
                LastThreeProjects = lastThreeProjects
            };

            return View(viewModel);
        }
    }
}
