
using System.ComponentModel.DataAnnotations;

namespace MYAcademy_PortfolioProject.Entities
{
    public class Experience
    {
        public int ExperienceId { get; set; }

        [Required(ErrorMessage = "Deneyim başlığı zorunludur.")]
        [StringLength(150, ErrorMessage = "Başlık en fazla 150 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Şirket adı zorunludur.")]
        [StringLength(150, ErrorMessage = "Şirket adı en fazla 150 karakter olabilir.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Kategori adı en fazla 100 karakter olabilir.")]
        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
    }
}
