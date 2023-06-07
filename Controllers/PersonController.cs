using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;


namespace ForekOnlineApplication.Controllers
{
    public class PersonController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyf;

        public PersonController(AppDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                person.PersonId = Helper.Utility.GenerateGuid();
                person.IsActive = true;
                person.CreatedOn = Helper.Utility.CurrentDateTime();
                person.CreatedBy = person.FirstName;

                await _context.Persons.AddAsync(person);
                var rc = await _context.SaveChangesAsync();

                if (rc > 0)
                {
                    _notyf.Success("Profile has been successfully Added");

                    return RedirectToAction("AddAddress", "Address",new {PersonId = person.PersonId});

                }
                else
                {
                    _notyf.Error("Profile could not be Added");
                }

                return RedirectToAction("AddAddress", "Address");
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
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Person updatedPerson)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            person.Title = updatedPerson.Title;
            person.FirstName = updatedPerson.FirstName;
            person.LastName = updatedPerson.LastName;
            person.Age = updatedPerson.Age;
            person.DateOfBirth = updatedPerson.DateOfBirth;
            person.Race = updatedPerson.Race;
            person.Gender = updatedPerson.Gender;

            _context.Persons.Update(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FirstOrDefaultAsync(
                m => m.PersonId == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }


        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Persons == null)
            {
                return Problem("Entity set 'MvcPersonContext.Person'  is null.");
            }

            var person = await _context.Persons.FindAsync(id);
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Index()
        {
            var persons = await _context.Persons.ToListAsync();
            return View(persons);
        }

        private bool PersonExists(Guid id)
        {
            return _context.Persons.Any(e => e.PersonId == id);
        }
    }
}
