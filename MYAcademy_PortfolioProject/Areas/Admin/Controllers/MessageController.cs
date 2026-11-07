using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly PortfolioContext _context;

        public MessageController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult MessageList(string searchQuery)
        {
            var values = _context.Messages.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();

                values = values.Where(x => x.SenderName.Contains(searchQuery) || x.SenderEmail.Contains(searchQuery) || (x.Subject != null && x.Subject.Contains(searchQuery))
                );
            }

            values = values.OrderByDescending(x => x.SendDate);
            ViewBag.SearchQuery = searchQuery;
            return View(values.ToList());
        }

        [HttpGet]
        public IActionResult GetMessageDetail(int id)
        {
            var message = _context.Messages.FirstOrDefault(x => x.MessageId == id);

            if (message == null)
                return NotFound();

            if (!message.IsRead)
            {
                message.IsRead = true;
                _context.SaveChanges();
            }

            return Json(message);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteMessage(int id)
        {
            var message = _context.Messages.FirstOrDefault(x => x.MessageId == id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(message);
            _context.SaveChanges();

            return RedirectToAction("MessageList");
        }
    }
}
