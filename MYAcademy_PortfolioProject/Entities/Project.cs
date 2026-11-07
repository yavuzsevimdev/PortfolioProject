
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MYAcademy_PortfolioProject.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Proje başlığı zorunludur.")]
        [StringLength(150, ErrorMessage = "Proje başlığı en fazla 150 karakter olabilir.")]
        public string ProjectTitle { get; set; }

        [Required(ErrorMessage = "Proje açıklaması zorunludur.")]
        [StringLength(2000, ErrorMessage = "Proje açıklaması en fazla 2000 karakter olabilir.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Proje görseli zorunludur.")]
        [StringLength(1500, ErrorMessage = "Görsel adresi en fazla 1500 karakter olabilir.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "GitHub adresi zorunludur.")]
        [StringLength(1500, ErrorMessage = "GitHub adresi en fazla 1500 karakter olabilir.")]
        [Url(ErrorMessage = "Geçerli bir GitHub adresi giriniz.")]
        public string GithubUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Proje kategorisi seçilmelidir.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<ProjectTechnology> ProjectTechnologies { get; set; }
            = new List<ProjectTechnology>();
    }
}
