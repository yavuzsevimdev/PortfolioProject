using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;

namespace MYAcademy_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultFeaturedProjectsComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultFeaturedProjectsComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var projects = _context.Projects.Where(x => x.IsActive).Include(x => x.Category).Include(x => x.ProjectTechnologies).OrderByDescending(x => x.CreatedDate).ToList();
            return View(projects);
        }
    }
}
