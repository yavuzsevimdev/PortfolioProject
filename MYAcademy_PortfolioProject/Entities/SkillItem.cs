
using System.ComponentModel.DataAnnotations;

namespace MYAcademy_PortfolioProject.Entities
{
    public class SkillItem
    {
        public int SkillItemId { get; set; }

        [Required(ErrorMessage = "Yetenek maddesi zorunludur.")]
        [StringLength(100, ErrorMessage = "Yetenek maddesi en fazla 100 karakter olabilir.")]
        public string SkillItemTitle { get; set; }

        [Required(ErrorMessage = "Yetenek kategorisi seçilmelidir.")]
        public int SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}
