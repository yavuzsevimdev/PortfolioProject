using Microsoft.AspNetCore.Mvc;
using MYAcademy_PortfolioProject.Context;
using MYAcademy_PortfolioProject.Entities;

namespace MYAcademy_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly PortfolioContext _context;

        public ContactController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ContactList()
        {
            var values = _context.Contacts.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {

            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "İletişim bilgisi başarıyla eklendi.";
            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public IActionResult UpdateContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }


            var updatedContact = _context.Contacts.Find(contact.ContactId);
            if (updatedContact != null)
            {
                updatedContact.Title = contact.Title;
                updatedContact.Description = contact.Description;
                updatedContact.Email = contact.Email;
                updatedContact.Location = contact.Location;
                updatedContact.PhoneNumber = contact.PhoneNumber;
                _context.SaveChanges();
            }

            TempData["SuccessMessage"] = "İletişim bilgisi başarıyla güncellendi.";
            return RedirectToAction("ContactList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);

            if (value == null)
                return NotFound();

            _context.Contacts.Remove(value);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "İletişim bilgisi başarıyla silindi.";
            return RedirectToAction("ContactList");
        }
    }
}
