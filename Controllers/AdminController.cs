using IWantMyMummy.Areas.Identity.Data;
using IWantMyMummy.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWantMyMummy.Controllers
{
    public class AdminController : Controller
    {

        private UserManager<IWantMyMummyUser> userManager;
        private readonly ILogger<AdminController> _logger;
        private IWantMyMummyContext context;

        public AdminController(ILogger<AdminController> logger, IWantMyMummyContext con, UserManager<IWantMyMummyUser> tempUser)
        {
            context = con;
            _logger = logger;
            userManager = tempUser;
        }

        public IActionResult Index()
        {
            var role = (context.UserRoles
            .Where(r => r.UserId == userManager.GetUserId(User))
            .FirstOrDefault());

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }
            return View(context.Users);
        }

        [HttpGet]
        public IActionResult EditUser()
        {
            var role = (context.UserRoles
                        .Where(r => r.UserId == userManager.GetUserId(User))
                        .FirstOrDefault());

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }
            return View();
        }
       

    }
}
