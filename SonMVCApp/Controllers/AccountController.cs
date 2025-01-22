using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SonMVCApp.Models;
using SonMVCApp.ViewModels;

namespace SonMVCApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<IdentityRole> role;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> role)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.role = role;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm vm)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = new AppUser()
            {
                Name = vm.Name,
                Email = vm.Email,
                UserName = vm.UserName
            };

            var result = await userManager.CreateAsync(appUser, vm.Password);
            await userManager.AddToRoleAsync(appUser, Roles.Admin.ToString());
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                    
                }
                return View();
            }
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginVm vm)
        {
            if (!ModelState.IsValid) return View();
            var agent=await userManager.FindByNameAsync(vm.EmailOrUserName)
                ?? await userManager.FindByEmailAsync(vm.EmailOrUserName);
            if (agent == null)
            {
                ModelState.AddModelError("", "Melumatlar duzgun deyil");
                return View();
            }
            var result=await signInManager.CheckPasswordSignInAsync(agent, vm.Password,true);
            if (!result.Succeeded) 
            {
                ModelState.AddModelError("", "Melumatlar duzgun deyil");
                return View();
            }
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Az sonra yeniden cehd et");
                return View();
            }
            await signInManager.SignInAsync(agent,true);
            return RedirectToAction(nameof(Index),"Home");

        }

        public async Task<IActionResult> CreateRole()
        {
            foreach (var item in Enum.GetValues(typeof(Roles)))
            {
                await role.CreateAsync(new IdentityRole()
                {
                    Name = item.ToString()
                });
            }
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
    }
}
