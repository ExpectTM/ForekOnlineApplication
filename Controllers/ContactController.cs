using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddContact()
        {
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
