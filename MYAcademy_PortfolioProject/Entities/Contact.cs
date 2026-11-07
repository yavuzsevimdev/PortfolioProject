
using System.ComponentModel.DataAnnotations;

namespace MYAcademy_PortfolioProject.Entities
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(150, ErrorMessage = "Başlık en fazla 150 karakter olabilir.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "E-posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [StringLength(150, ErrorMessage = "E-posta adresi en fazla 150 karakter olabilir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Konum alanı zorunludur.")]
        [StringLength(150, ErrorMessage = "Konum en fazla 150 karakter olabilir.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [StringLength(20, ErrorMessage = "Telefon numarası en fazla 20 karakter olabilir.")]
        public string PhoneNumber { get; set; }
    }
}
