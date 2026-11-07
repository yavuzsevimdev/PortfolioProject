using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly PortfolioContext _context;

        public DefaultController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SendMessage(Message message)
        {
            if (!ModelState.IsValid)
            {
                TempData["MessageError"] = "Lütfen form alanlarını kontrol ederek tekrar deneyiniz.";
                return RedirectToAction("Index");
            }

            message.SendDate = DateTime.UtcNow;
            message.IsRead = false;

            _context.Messages.Add(message);
            _context.SaveChanges();

            TempData["MessageSuccess"] = "Mesajınız başarıyla gönderildi. En kısa sürede sizinle iletişime geçeceğiz.";

            return RedirectToAction("Index");
        }
    }
}
