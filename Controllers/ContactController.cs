using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ForekOnlineApplication.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyf;
        public ContactController(AppDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;

        }

        [HttpGet]
        public async Task<IActionResult> AddContact(Guid PersonId)
        {
            if (PersonId == Guid.Empty)
            {
                return NotFound();
            }

            Person person = await _context.Persons.FindAsync(PersonId);

            if (person is null)
            {
                return NotFound();
            }

            ViewData["user"] = $"{person.FirstName} {person.LastName}";

            ViewData["Id"] = person.PersonId;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                contact.ContactId = Helper.Utility.GenerateGuid();
                await _context.Contacts.AddAsync(contact);
                var rc = await _context.SaveChangesAsync();

                if (rc > 0)
                {
                    _notyf.Success("Contact has been successfully Added");
                    return RedirectToAction("AddGuardian", "Guardian", new { PersonId = contact.PersonId });
                }
                else
                {
                    _notyf.Error("Contact could not be Added");
                }

            }
            else
            {
                _notyf.Error("An Error occurred");
            }
            return View();


        }

    }
}
