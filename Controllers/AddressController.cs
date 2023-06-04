using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddAddress()
        {
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
                }
                else
                {
                    _notyf.Error("Address could not be Added");
                }

                return RedirectToAction("AddGuardian", "Guardian");
            }
            else
            {
                _notyf.Error("An Error occurred");
            }

            return View();
        }
        

    }
}
