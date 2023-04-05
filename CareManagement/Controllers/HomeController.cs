using CareManagement.Models;
using EmailService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CareManagement.Data;
using CareManagement.Models.SCHDL;
using Microsoft.AspNetCore.Identity;
using CareManagement.Models.AUTH;

namespace CareManagement.Controllers
{
    public class HomeController : Controller
    {
        public const String ADMIN_ROLE = "Admin";
        public const String EMPLOYEE_ROLE = "Employee";
        private IdentityRole admin;
        private IdentityRole employee;

        private readonly ILogger<HomeController> _logger;
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userMgr, RoleManager<IdentityRole> roleMgr)
        {
            _logger = logger;
            userManager = userMgr;
            roleManager = roleMgr;
            Task createRoleTask = createRole();
            Task.WaitAll(createRoleTask);
        }

        public async Task createRole()
        {
            if (roleManager.Roles.Any())
            {
                admin = await roleManager.FindByNameAsync(ADMIN_ROLE);
                employee = await roleManager.FindByNameAsync(EMPLOYEE_ROLE);
                return;
            }

            System.Diagnostics.Debug.WriteLine("Creating roles");
            admin = new IdentityRole(ADMIN_ROLE);
            employee = new IdentityRole(EMPLOYEE_ROLE);
            await roleManager.CreateAsync(admin);
            await roleManager.CreateAsync(employee);

            if (!userManager.Users.Any())
            {
                AppUser user1 = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@test.com",
                    Role = "Admin"
                };
                AppUser user2 = new AppUser
                {
                    UserName = "user",
                    Email = "user@test.com",
                    Role = "Employee"
                };
                await userManager.CreateAsync(user1, "Admin_123");
                await userManager.CreateAsync(user2, "User_123");
                System.Diagnostics.Debug.WriteLine("Added Accounts");

                await userManager.AddToRoleAsync(user1, admin.Name);
                await userManager.AddToRoleAsync(user2, employee.Name);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}