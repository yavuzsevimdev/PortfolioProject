
using System.ComponentModel.DataAnnotations;

namespace MYAcademy_PortfolioProject.Entities
{
    public class ProjectTechnology
    {
        public int ProjectTechnologyId { get; set; }

        [Required(ErrorMessage = "Teknoloji adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Teknoloji adı en fazla 100 karakter olabilir.")]
        public string TechnologyName { get; set; }

        [Required(ErrorMessage = "Proje seçilmelidir.")]
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
