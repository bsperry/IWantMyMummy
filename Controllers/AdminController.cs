using IWantMyMummy.Areas.Identity.Data;
using IWantMyMummy.Data;
using IWantMyMummy.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

                var viewModel =
        from user in context.Users
        join userrole in context.UserRoles on user.Id equals userrole.UserId
        join roledef in context.Roles on userrole.RoleId equals roledef.Id
        orderby user.LastName
        select new UsersRolesViewModel { mummyUser = user, identityUserRole = userrole, identityRole = roledef };


                return View(viewModel);
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
            //    .Join(context.UserRoles)
            //    .Where(u => u.Id == userId)
            //    .FirstOrDefault();



            var user =
                        (from u in context.Users
                         join r in context.UserRoles on u.Id equals r.UserId into ps
                         from r in ps.DefaultIfEmpty()
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


            List<string> RoleList = new List<string>();
            RoleList.Add("Public");
            RoleList.Add("Researcher");
            RoleList.Add("Admin");

            ViewBag.RoleList = RoleList;

            return View();
        }


        [HttpPost("EditUser")]
        public IActionResult EditUser(IWantMyMummyUser user, string roleId)
        {
            if (ModelState.IsValid)
            {
                //context.Users.Update(user);
                //context.SaveChanges();

                var updateUsers = (from use in context.Users
                                   where use.Id == user.Id
                                   select use).FirstOrDefault();

                updateUsers.Firstname = user.Firstname;
                updateUsers.LastName = user.LastName;
                updateUsers.Email = user.Email;
                updateUsers.PhoneNumber = user.PhoneNumber;

                context.SaveChanges();

                var updateRole = (from rol in context.UserRoles
                                  where rol.UserId == user.Id
                                  select rol).FirstOrDefault();

                if (updateRole != null)
                {

                    context.UserRoles.Remove(updateRole);

                    context.SaveChanges();

                    updateRole.RoleId = roleId;
                    context.UserRoles.Add(updateRole);

                }
                else
                {
                    var row = new IdentityUserRole<string>
                    {
                        RoleId = roleId,
                        UserId = user.Id
                    };

                    context.UserRoles.Add(row);
                }



                context.SaveChanges();


                var role = (context.UserRoles
                    .Where(r => r.UserId == userManager.GetUserId(User))
                    .FirstOrDefault());


                if (!(role is null))
                {
                    ViewBag.Role = Int32.Parse(role.RoleId);
                }

                return RedirectToAction("index", "Admin");
            }

            return View("Index", context.Users);

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
