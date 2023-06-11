using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
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

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> AddCourses()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCourses(Course course)
        {
            if (ModelState.IsValid)
            {
                course.CourseId = Helper.Utility.GenerateGuid();
                await _context.Courses.AddAsync(course);
                var rc = await _context.SaveChangesAsync();

                if (rc > 0)
                {
                    _notyf.Success("You have successfully added Course");
                    return RedirectToAction("Index", "Course");
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


        [HttpGet]
        public async Task<IActionResult> SelectCourse(Guid PersonId)
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

            await LoadCourseNames();
            return View();
        }

        [NonAction]
        private async Task LoadCourseNames()
        {
            var courseNames = await _context.Courses.ToListAsync();
            ViewBag.Courses = new SelectList(courseNames, "CourseId", "CourseName");
        }

        [HttpGet]
        public async Task<IActionResult> GetCourseInfo(Guid CourseId)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == CourseId);

            if (course == null)
            {
                return NotFound();
            }

            var courseInfo = new
            {
                
                CourseType = course.CourseType,
                CourseDescription = course.CourseDescription,
                CourseNQL = course.NQL,
                CourseModules = course.Modules
            };

            return Json(courseInfo);
        }


        [HttpPost]
        public async Task<IActionResult> SelectCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                course.CourseId = Helper.Utility.GenerateGuid();
                await _context.Courses.AddAsync(course);
                var rc = await _context.SaveChangesAsync();

                if (rc > 0)
                {
                    _notyf.Success("You have successfully add Course");
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




        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Course updatedCourse)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            course.CourseName = updatedCourse.CourseName;
            course.CourseType = updatedCourse.CourseType;
            course.NQL = updatedCourse.NQL;
            course.Modules = updatedCourse.Modules; 
            course.CourseDescription = updatedCourse.CourseDescription;
           
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index" , "Course");
        }



        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FirstOrDefaultAsync(
                m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }


        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'MvcPersonContext.Course'  is null.");
            }

            var course = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Course");
        }


        public async Task<IActionResult> Index()
        {
            var persons = await _context.Courses.ToListAsync();
            return View(persons);
        }

        private bool CourseExists(Guid id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }

    }
}
