
using System.ComponentModel.DataAnnotations;

namespace MYAcademy_PortfolioProject.Entities
{
    public class About
    {
        public int AboutId { get; set; }

        [Required(ErrorMessage = "Ad soyad alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Ad soyad en fazla 100 karakter olabilir.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(150, ErrorMessage = "Başlık en fazla 150 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Profil görseli URL alanı zorunludur.")]
        [StringLength(500, ErrorMessage = "Görsel URL en fazla 500 karakter olabilir.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Konum alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Konum en fazla 100 karakter olabilir.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Meslek alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Meslek en fazla 100 karakter olabilir.")]
        public string Profession { get; set; }

        [Required(ErrorMessage = "1. istatistik değeri zorunludur.")]
        [StringLength(30, ErrorMessage = "İstatistik değeri en fazla 30 karakter olabilir.")]
        public string StatisticValue1 { get; set; }

        [Required(ErrorMessage = "1. istatistik başlığı zorunludur.")]
        [StringLength(50, ErrorMessage = "İstatistik başlığı en fazla 50 karakter olabilir.")]
        public string StatisticTitle1 { get; set; }

        [Required(ErrorMessage = "2. istatistik değeri zorunludur.")]
        [StringLength(30, ErrorMessage = "İstatistik değeri en fazla 30 karakter olabilir.")]
        public string StatisticValue2 { get; set; }

        [Required(ErrorMessage = "2. istatistik başlığı zorunludur.")]
        [StringLength(50, ErrorMessage = "İstatistik başlığı en fazla 50 karakter olabilir.")]
        public string StatisticTitle2 { get; set; }

        [Required(ErrorMessage = "3. istatistik değeri zorunludur.")]
        [StringLength(30, ErrorMessage = "İstatistik değeri en fazla 30 karakter olabilir.")]
        public string StatisticValue3 { get; set; }

        [Required(ErrorMessage = "3. istatistik başlığı zorunludur.")]
        [StringLength(50, ErrorMessage = "İstatistik başlığı en fazla 50 karakter olabilir.")]
        public string StatisticTitle3 { get; set; }

        [StringLength(500, ErrorMessage = "CV URL en fazla 500 karakter olabilir.")]
        public string CvUrl { get; set; }
    }
}
