using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForekOnlineApplication.Controllers
{
    public class QualificationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyf;

        public QualificationController(AppDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }
        public async Task<IActionResult> AddQualification(Guid PersonId)
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
        public async Task<IActionResult> AddQualification(Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                qualification.Id = Helper.Utility.GenerateGuid();
                await _context.Qualifications.AddAsync(qualification);
                var rc = await _context.SaveChangesAsync();

                if (rc > 0)
                {
                    _notyf.Success("Qualification details has been successfully Added");
                    return RedirectToAction("SelectCourse", "Course", new { PersonId = qualification.PersonId });
                }
                else
                {
                    _notyf.Error("Qualification details could not be Added");
                }

                return RedirectToAction("AddCourse", "Course");
            }
            else
            {
                _notyf.Error("An Error occurred");
            }

            return View();
        }
    }
}
