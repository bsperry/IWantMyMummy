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

        [HttpGet("EditUser")]
        public IActionResult EditUser(string userId)
        {
            var role = (context.UserRoles
                        .Where(r => r.UserId == userManager.GetUserId(User))
                        .FirstOrDefault());

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }


            //var user = context.Users
            //	.Join(context.UserRoles)
            //	.Where(u => u.Id == userId)
            //	.FirstOrDefault();

            var user =
                        (from u in context.Users
                         join r in context.UserRoles on u.Id equals r.UserId
                         select new { FirstName = u.Firstname, LastName = u.LastName, PhoneNumer = u.PhoneNumber, Email = u.Email, UserId = u.Id, RoleId = r.RoleId });
            var test = user
                .Where(r => r.UserId == userId);

            //ViewBag.User = test;



            foreach (var u in test)
            {
                ViewBag.FirstName = u.FirstName;
                ViewBag.LastName = u.LastName;
                ViewBag.Email = u.Email;
                ViewBag.PhoneNumber = u.PhoneNumer;
                ViewBag.UserId = u.UserId;
                ViewBag.UserRole = u.RoleId;

            }



            return View();
        }


        [HttpPost]
        public IActionResult EditUser(IWantMyMummyUser user)
        {
            if (ModelState.IsValid)
            {
                var role = (context.UserRoles
                    .Where(r => r.UserId == userManager.GetUserId(User))
                    .FirstOrDefault());

                if (!(role is null))
                {
                    ViewBag.Role = Int32.Parse(role.RoleId);
                }

                return View("Index", context.Users);
            }

            return View();

        }
       
        [HttpPost]

        public IActionResult DeleteUser(string userId)
        {
            var deleteUser = context.Users
                                .Where(u => u.Id == userId)
                                .FirstOrDefault();

            var deleteUserRole = context.UserRoles
                                    .Where(ur => ur.UserId == userId)
                                    .FirstOrDefault();

            context.Users.Remove(deleteUser);
            context.UserRoles.Remove(deleteUserRole);
            context.SaveChanges();


            return RedirectToAction("Index");
        }

    }
}
