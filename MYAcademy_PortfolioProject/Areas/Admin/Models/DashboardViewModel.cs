using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Models
{
    public class DashboardViewModel
    {
        public int TotalProjectCount { get; set; }
        public int ActiveProjectCount { get; set; }
        public int SkillCount { get; set; }
        public int ExperienceCount { get; set; }
        public int EducationCount { get; set; }
        public int TotalMessageCount { get; set; }
        public int TotalUnreadMessageCount { get; set; }
        public List<Message> LastFiveMessages { get; set; }
        public List<Category> Categories { get; set; }
        public List<Project> LastThreeProjects { get; set; }
    }
}
