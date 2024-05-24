using imtahan.Areas.Admin.ViewModel;
using imtahan.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace imtahan.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }




        public async Task<IActionResult> CreateRoles()
        {
            IdentityRole role1 = new IdentityRole("Admin");
            IdentityRole role2 = new IdentityRole("Member");

            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);

            return Ok("Rollar yaradildi...");
        }


        public async Task<IActionResult> CreateAdmin()
        {
            AppUser admin = new AppUser()
            {
                Fullname = "admin",
                UserName = "admin",
            };

            await _userManager.CreateAsync(admin, "Admin123@");
            await _userManager.AddToRoleAsync(admin, "Admin");

            return Ok("Admin yaradildi...");

        }







        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginVm vm)
        {

            if (!ModelState.IsValid)
                return View();

            var admin = await _userManager.FindByNameAsync(vm.Login);

            if (admin == null)
            {
                ModelState.AddModelError("", "Username or password is incorrect!");
                return View();
            }

            var check = await _userManager.CheckPasswordAsync(admin, vm.Password);

            if (!check)
            {
                ModelState.AddModelError("", "Username or password is incorrect!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(admin, vm.Password, false, false);

            return RedirectToAction("Index", "Dashboard");

        }

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }




    }
}
