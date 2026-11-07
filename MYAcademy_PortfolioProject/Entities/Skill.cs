
using System.ComponentModel.DataAnnotations;

namespace MYAcademy_PortfolioProject.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }

        [Required(ErrorMessage = "Yetenek başlığı zorunludur.")]
        [StringLength(100, ErrorMessage = "Yetenek başlığı en fazla 100 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [StringLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "İkon sınıfı zorunludur.")]
        [StringLength(100, ErrorMessage = "İkon sınıfı en fazla 100 karakter olabilir.")]
        public string IconUrl { get; set; }

        public List<SkillItem> SkillItems { get; set; } = new List<SkillItem>();
    }
}
