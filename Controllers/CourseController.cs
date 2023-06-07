using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForekOnlineApplication.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyf;

        public CourseController(AppDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }
        public async Task<IActionResult> AddCourse(Guid PersonId)
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
        public async Task<IActionResult> AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                course.CourseId = Helper.Utility.GenerateGuid();
                await _context.Courses.AddAsync(course);
                var rc = await _context.SaveChangesAsync();

                if (rc > 0)
                {
                    _notyf.Success("You have successfully apply at Forek Institution of Technology");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    _notyf.Error("Course details could not be Added");
                }

                return View();
            }
            else
            {
                _notyf.Error("An Error occurred");
            }

            return View();
        }
    }
}
