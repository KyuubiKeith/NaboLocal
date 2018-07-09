using NaboUI.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System.Web.Mvc;

namespace NaboUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _usermanager;
        private readonly SignInManager<IdentityUser> _signinManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _usermanager = userManager;
            _signinManager = signInManager;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Register(RegisterViewModel vm)
        {

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { Username = vm.Email, Email = vm.Email };
                var result = await _usermanager.CreateAsync(user, vm.Password);

                if (result.succeeded)
                {

                    await _signinManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");

                }
                else
                {

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(" ", error.Description);
                    }
                }
                return View(vm);
            }
        }
    }

    internal class ApplicationUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}