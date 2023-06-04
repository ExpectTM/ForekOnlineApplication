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
        public async Task<IActionResult> AddGuardian()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuardian(Guardian guardian)
        {
            if (ModelState.IsValid)
            {

                guardian.GuardianId = Helper.Utility.GenerateGuid();
                
                await _context.Guardians.AddAsync(guardian);
                var rc = await _context.SaveChangesAsync();

                if (rc > 0)
                {
                    _notyf.Success("Guardian has been successfully Added");
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

            return View();
        }
    }
}
