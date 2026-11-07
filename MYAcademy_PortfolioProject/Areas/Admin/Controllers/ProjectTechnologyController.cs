using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectTechnologyController : Controller
    {
        private readonly PortfolioContext _context;

        public ProjectTechnologyController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ProjectTechnologyList(int projectId)
        {
            var project = _context.Projects.FirstOrDefault(x => x.ProjectId == projectId);
            if (project == null)
                return NotFound();

            var values = _context.ProjectTechnologies.Where(x => x.ProjectId == projectId).ToList();
            ViewBag.ProjectId = projectId;
            ViewBag.ProjectTitle = project.ProjectTitle;
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProjectTechnology(int projectId)
        {
            var project = _context.Projects.FirstOrDefault(x => x.ProjectId == projectId);
            if (project == null)
                return NotFound();

            ViewBag.ProjectTitle = project.ProjectTitle;
            return View(new ProjectTechnology
            {
                ProjectId = projectId
            });
        }

        [HttpPost]
        public IActionResult CreateProjectTechnology(ProjectTechnology projectTechnology)
        {
            if (!ModelState.IsValid)
            {
                return View(new { projectId = projectTechnology.ProjectId });
            }
            var projectExists = _context.Projects.Any(x => x.ProjectId == projectTechnology.ProjectId);

            if (!projectExists)
                return NotFound();

            _context.ProjectTechnologies.Add(projectTechnology);
            _context.SaveChanges();

            return RedirectToAction("ProjectTechnologyList", new
            {
                projectId = projectTechnology.ProjectId
            });
        }

        [HttpPost]
        public IActionResult DeleteProjectTechnology(int id)
        {
            var value = _context.ProjectTechnologies.Find(id);

            if (value == null)
                return NotFound();

            int projectId = value.ProjectId;

            _context.ProjectTechnologies.Remove(value);
            _context.SaveChanges();

            return RedirectToAction("ProjectTechnologyList", new
            {
                projectId
            });
        }
    }
}
