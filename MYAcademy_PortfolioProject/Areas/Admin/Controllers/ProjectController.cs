using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly PortfolioContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProjectController(PortfolioContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private async Task<string> SaveImage(IFormFile imageFile)
        {
            var extension = Path.GetExtension(imageFile.FileName).ToLowerInvariant();
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".webp" };
            if (!allowedExtensions.Contains(extension))
                throw new Exception("Sadece JPG, JPEG, PNG ve WEBP dosyaları yüklenebilir.");
            if (imageFile.Length > 5 * 1024 * 1024)
                throw new Exception("Görsel boyutu en fazla 5 MB olabilir.");
            var folderPath = Path.Combine(
                _environment.WebRootPath,
                "images",
                "projects"
            );

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(folderPath, fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            return $"/images/projects/{fileName}";
        }

        private void DeleteImage(string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
                return;

            var fileName = Path.GetFileName(imageUrl);

            var filePath = Path.Combine(
                _environment.WebRootPath,
                "images",
                "projects",
                fileName
            );

            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }

        private void LoadCategories(int? selectedCategoryId = null)
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName", selectedCategoryId);
        }

        public IActionResult ProjectList()
        {
            var values = _context.Projects.Include(x => x.Category).Include(x => x.ProjectTechnologies).ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProject()
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(Project project, IFormFile imageFile)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories(project.CategoryId);
                return View(project);
            }
            if (imageFile == null || imageFile.Length == 0)
            {
                ModelState.AddModelError("", "Lütfen proje görseli seçiniz.");
            }

            ModelState.Remove(nameof(Project.ImageUrl));
            ModelState.Remove(nameof(Project.Category));
            ModelState.Remove(nameof(Project.ProjectTechnologies));

            if (!ModelState.IsValid)
            {
                LoadCategories(project.CategoryId);
                return View(project);
            }

            try
            {
                project.ImageUrl = await SaveImage(imageFile);
                project.CreatedDate = DateTime.Now;

                _context.Projects.Add(project);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Proje başarıyla eklendi.";
                return RedirectToAction("ProjectList");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                LoadCategories(project.CategoryId);
                TempData["ErrorMessage"] = "Proje eklenirken bir hata oluştu.";
                return View(project);
            }
        }

        [HttpGet]
        public IActionResult UpdateProject(int id)
        {
            var value = _context.Projects.Find(id);
            if (value == null)
                return NotFound();

            LoadCategories(value.CategoryId);
            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProject(Project project, IFormFile? imageFile)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories(project.CategoryId);
                return View(project);
            }
            var value = _context.Projects.Find(project.ProjectId);
            if (value == null)
                return NotFound();

            ModelState.Remove(nameof(Project.ImageUrl));
            ModelState.Remove(nameof(Project.Category));
            ModelState.Remove(nameof(Project.ProjectTechnologies));

            if (!ModelState.IsValid)
            {
                LoadCategories(project.CategoryId);
                return View(project);
            }

            value.IsActive = project.IsActive;
            value.ProjectTitle = project.ProjectTitle;
            value.Description = project.Description;
            value.GithubUrl = project.GithubUrl;
            value.CategoryId = project.CategoryId;

            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var oldImageUrl = value.ImageUrl;

                    value.ImageUrl = await SaveImage(imageFile);

                    await _context.SaveChangesAsync();

                    DeleteImage(oldImageUrl);
                }
                else
                {
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("ProjectList");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                LoadCategories(value.CategoryId);
                return View(project);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProject(int id)
        {
            var value = _context.Projects.Find(id);

            if (value == null)
            {
                TempData["ErrorMessage"] = "Silinecek proje bulunamadı.";
                return RedirectToAction("ProjectList");
            }

            _context.Projects.Remove(value);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Proje başarıyla silindi.";

            return RedirectToAction("ProjectList");
        }
    }
}
