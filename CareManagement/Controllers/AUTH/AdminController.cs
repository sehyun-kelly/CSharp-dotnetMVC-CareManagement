using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CareManagement.Models.AUTH;
using CareManagement.Models.SCHDL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CareManagement.Controllers.AUTH
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private IPasswordHasher<AppUser> passwordHasher;

        public AdminController(UserManager<AppUser> usrMgr, IPasswordHasher<AppUser> passwordHash)
        {
            userManager = usrMgr;
            passwordHasher = passwordHash;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(userManager.Users);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = user.Name,
                    Email = user.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, user.Password);

                if (result.Succeeded) {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(user);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(String? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(String id, String username, String email, String password, String? newPassword)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                bool allow = true;

                if (passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) != PasswordVerificationResult.Success)
                {
                    ModelState.AddModelError("", "Password does not match");
                    allow = false;
                }

                if (!string.IsNullOrEmpty(username))
                    user.UserName = username;
                else
                {
                    ModelState.AddModelError("", "Username cannot be empty");
                    allow = false;
                }

                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                {
                    ModelState.AddModelError("", "Email cannot be empty");
                    allow = false;
                }

                if (!string.IsNullOrEmpty(newPassword))
                    user.PasswordHash = passwordHasher.HashPassword(user, newPassword);
                else
                {
                    ModelState.AddModelError("", "Password cannot be empty");
                    allow = false;
                }

                if (allow)
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(String? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(String id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return RedirectToAction("Index");
        }
        
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}