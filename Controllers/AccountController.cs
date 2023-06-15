using AspNetCoreHero.ToastNotification.Abstractions;
using ForekOnlineApplication.Data;
using ForekOnlineApplication.Models;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Net;

namespace ForekOnlineApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyf;

        public AccountController(AppDbContext context, INotyfService notyf)
        {
            _context = context;
            _notyf = notyf;

        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(Account account)
        {
            if (ModelState.IsValid)
            {

                if (_context.Accounts.Any(a => a.Username == account.Username))
                {
                    ModelState.AddModelError(nameof(account.Username), "Username already exists.");
                    return View(account);
                }
                account.Id = Helper.Utility.GenerateGuid();
                _context.Accounts.Add(account);
                _context.SaveChanges();

                return RedirectToAction("Signin");
            }

            return View(account);
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signin(Account account)
        {
            if (ModelState.IsValid)
            {
                var existingAccount = _context.Accounts.FirstOrDefault(a => a.Username == account.Username);

                if (existingAccount != null && existingAccount.Password == account.Password)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, existingAccount.Username)
                    
                };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Invalid username or password.");
            }

            return View(account);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}