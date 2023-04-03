using System;
using CareManagement.Models.AUTH;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CareManagement.Controllers.AUTH
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }
        
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl)
        {
            Login login = new Login();
            login.ReturnUrl = returnUrl;
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = await userManager.FindByEmailAsync(login.Email);
                AppUser? test = userManager.Users.FirstOrDefault(x => x.NormalizedEmail == login.Email);
                System.Diagnostics.Debug.WriteLine(test?.Email);

                if (appUser != null)
                {
                    await signInManager.SignOutAsync();
                    IPasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
                    System.Diagnostics.Debug.WriteLine(passwordHasher.VerifyHashedPassword(appUser, appUser.PasswordHash, login.Password));
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);
                    System.Diagnostics.Debug.WriteLine(result);
                    if (result.Succeeded)
                        return Redirect(login.ReturnUrl ?? "/");
                }
                ModelState.AddModelError(nameof(login.Email), "Login Failed: Invalid Email or password");
            }
            return View(login);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

