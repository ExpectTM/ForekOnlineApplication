using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ForekOnlineApplication.Controllers
{
    public class SecondarySchoolController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyf;

        public SecondarySchoolController(AppDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }
        [HttpGet]
        public async Task<IActionResult> AddSchool(Guid PersonId)
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
            public async Task<IActionResult> AddSchool(SecondarySchool school)
            {
                if (ModelState.IsValid)
                {
                    school.HighSchoolId = Helper.Utility.GenerateGuid();
                    await _context.SecondarySchools.AddAsync(school);
                    var rc = await _context.SaveChangesAsync();

                    if (rc > 0)
                    {
                        _notyf.Success("High School details has been successfully Added");
                        return RedirectToAction("AddQualification", "Qualification", new { PersonId = school.PersonId });
                    }
                    else
                    {
                        _notyf.Error("High School details could not be Added");
                    }

                    return RedirectToAction("AddQualification", "Qualification");
                }
                else
                {
                    _notyf.Error("An Error occurred");
                }

                return View();
            }
        
    }
}
