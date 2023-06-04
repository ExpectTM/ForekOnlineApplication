using Microsoft.AspNetCore.Mvc;

namespace ForekOnlineApplication.Controllers
{
    public class ApplicantController : Controller
    {
        public IActionResult ApplicantUser()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddGuardian()
        {
            return View();
        }
    }
}
