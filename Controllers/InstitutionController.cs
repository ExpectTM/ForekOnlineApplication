using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForekOnlineApplication.Controllers
{
    public class InstitutionController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyf;

        public InstitutionController(AppDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;
        }
        public async Task<IActionResult> AddInstitution()
        {
            return View();
        }
        public async Task<IActionResult> AddInstitution(Institution institution) 
        {
            if (ModelState.IsValid)
            {

                institution.InstitutionId = Helper.Utility.GenerateGuid();

                await _context.Institutions.AddAsync(institution);
                var rc = await _context.SaveChangesAsync();

                if (rc > 0)
                {
                    _notyf.Success("Institution has been successfully Added");
                }
                else
                {
                    _notyf.Error("Institution could not be Added");
                }

                return RedirectToAction("AddHighSchool", "HighSchool");
            }
            else
            {
                _notyf.Error("An Error occurred");
            }
            return View();
        }
    }
}
