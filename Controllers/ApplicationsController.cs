using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;


namespace ForekOnlineApplication.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyf;

        public ApplicationsController(AppDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        [HttpGet]
        public async Task<IActionResult> AddApplications(Guid PersonId, Guid CourseId)
        {
            if (PersonId == Guid.Empty)
            {
                return NotFound();
            }
            if (CourseId == Guid.Empty)
            {
                return NotFound();
            }

            Person person = await _context.Persons.FindAsync(PersonId);
            Course course = await _context.Courses.FindAsync(CourseId);

            if (person is null)
            {
                return NotFound();
            }

            if (course is null)
            {
                return NotFound();
            }

            ViewData["PersonId"] = person.PersonId;
            ViewData["CourseId"] = course.PersonId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddApplications(Guid personId, Guid courseId, Applications applications)
        {
            if (ModelState.IsValid)
            {
                Applications application = new Applications
                {
                    CourseId = courseId,
                    PersenId = personId,
                    CourseName = CourseName;

                };

                applications.ApplicationsId = Helper.Utility.GenerateGuid();
                await _context.Application.AddAsync(applications);
                var rc = await _context.SaveChangesAsync();
                ModelState.Clear();

                if (rc > 0)
                {
                    _notyf.Success("You have successfully Applied at Forek Institution");

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    _notyf.Error("Apply submission failed. Please try again.");
                }

            }
            else
            {
                _notyf.Error("An error occurred while submitting the course. Please try again later.");
            }
            return View();
        }

    }   
}
