using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForekOnlineApplication.Controllers
{
    public class GuardianController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyf;

        public GuardianController(AppDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }
        //Adding Guardian
        [HttpGet]
        public async Task<IActionResult> AddGuardian(Guid PersonId)
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddGuardian(Guardian guardian)
        {
            if (ModelState.IsValid)
            {
                guardian.GuardianId = Helper.Utility.GenerateGuid();
                
                await _context.Guardians.AddAsync(guardian);
                var rc = await _context.SaveChangesAsync();
                ModelState.Clear();
                if (rc > 0)
                {
                    _notyf.Success("Guardian has been successfully Added");
                    return RedirectToAction("AddSchool", "SecondarySchool", new { PersonId = guardian.PersonId });
                }
                else
                {
                    _notyf.Error("Guardian could not be Added");
                }

                return RedirectToAction("AddSchool", "HighSchool");
            }
            else
            {
                _notyf.Error("An Error occurred");
            }

            return RedirectToAction("Index", "Home");
        }
        
    }
}
