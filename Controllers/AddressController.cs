using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ForekOnlineApplication.Controllers
{
    public class AddressController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyf;

        public AddressController(AppDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;

        }

        [HttpGet]
        public async Task<IActionResult> AddAddress(Guid PersonId)
        {
            if(PersonId == Guid.Empty)
            {
                return NotFound();
            }

            Person person = await _context.Persons.FindAsync(PersonId);

            if(person is null)
            {
                return NotFound();
            }

            ViewData["user"] = $"{person.FirstName} {person.LastName}";

            ViewData["Id"] = person.PersonId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAddress(Address address)
        {
            if (ModelState.IsValid)
            {
                address.AddressId = Helper.Utility.GenerateGuid();
                await _context.Addresses.AddAsync(address);
                var rc = await _context.SaveChangesAsync();

                if (rc > 0)
                {
                    _notyf.Success("Address has been successfully Added");

                    return RedirectToAction("AddContact", "Contact", new { PersonId = address.PersonId });
                }
                else
                {
                    _notyf.Error("Address could not be Added");
                }

                //return RedirectToAction("AddGuardian", "Guardian", new { PersonId = address.PersonId });
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
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            return View(address);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Address updatedAddress)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            address.AddressLine1 = updatedAddress.AddressLine1;
            address.AddressLine2 = updatedAddress.AddressLine2;
            address.PostalAddressLine1 = updatedAddress.PostalAddressLine1;
            address.PostalAddressLine2 = updatedAddress.PostalAddressLine2;
            address.Country = updatedAddress.Country;
            address.Country1 = updatedAddress.Country1;
            address.PostalCode = updatedAddress.PostalCode;

            _context.Addresses.Update(address);
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

            var address = await _context.Addresses.FirstOrDefaultAsync(
                m => m.AddressId == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }


        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Addresses == null)
            {
                return Problem("Entity set 'MvcAddressContext.Address'  is null.");
            }

            var address = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Index()
        {
            var address = await _context.Addresses.ToListAsync();
            return View(address);
        }

        private bool AddressExists(Guid id)
        {
            return _context.Addresses.Any(e => e.AddressId == id);
        }

    }
}
