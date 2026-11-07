
using System.ComponentModel.DataAnnotations;

namespace MYAcademy_PortfolioProject.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }

        [Required(ErrorMessage = "Platform adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Platform adı en fazla 100 karakter olabilir.")]
        public string PlatformName { get; set; }

        [Required(ErrorMessage = "İkon bilgisi zorunludur.")]
        [StringLength(250, ErrorMessage = "İkon bilgisi en fazla 250 karakter olabilir.")]
        public string IconUrl { get; set; }

        [Required(ErrorMessage = "Sosyal medya bağlantısı zorunludur.")]
        [StringLength(500, ErrorMessage = "Bağlantı en fazla 500 karakter olabilir.")]
        [Url(ErrorMessage = "Geçerli bir URL adresi giriniz.")]
        public string Url { get; set; }
    }
}
