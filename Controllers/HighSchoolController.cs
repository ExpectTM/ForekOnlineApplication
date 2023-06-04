﻿using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForekOnlineApplication.Controllers
{
    public class HighSchoolController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyf;

        public HighSchoolController(AppDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }
        public async Task<ActionResult> AddSchool()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSchool(HighSchool school)
        {
            if (ModelState.IsValid)
            {
                school.HighSchoolId = Helper.Utility.GenerateGuid();
                await _context.HighSchools.AddAsync(school);
                var rc = await _context.SaveChangesAsync();

                if (rc > 0)
                {
                    _notyf.Success("High School details has been successfully Added");
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
