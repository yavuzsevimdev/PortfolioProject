using System.ComponentModel.DataAnnotations;

namespace MYAcademy_PortfolioProject.Entities
{
    public class Education
    {
        public int EducationId { get; set; }

        [Required(ErrorMessage = "Eğitim derecesi zorunludur.")]
        [StringLength(100, ErrorMessage = "Eğitim derecesi en fazla 100 karakter olabilir.")]
        public string Degree { get; set; }

        [Required(ErrorMessage = "Bölüm adı zorunludur.")]
        [StringLength(200, ErrorMessage = "Bölüm adı en fazla 200 karakter olabilir.")]
        public string Department { get; set; }

        [StringLength(200, ErrorMessage = "Kurum adı en fazla 200 karakter olabilir.")]
        public string Institution { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Eğitim etiketi zorunludur.")]
        [StringLength(50, ErrorMessage = "Etiket en fazla 50 karakter olabilir.")]
        public string BadgeText { get; set; }

        public int DisplayOrder { get; set; } = 0;

        public bool IsActive { get; set; } = true;
    }
}
