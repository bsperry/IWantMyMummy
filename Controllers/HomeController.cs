using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IWantMyMummy.Models;
using IWantMyMummy.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using IWantMyMummy.Areas.Identity.Data;

namespace IWantMyMummy.Controllers
{
    public class HomeController : Controller
    {
       // const string SessionName = "Name";

        private UserManager<IWantMyMummyUser> userManager;
        private readonly ILogger<HomeController> _logger;
        private IWantMyMummyContext context;

        public HomeController(ILogger<HomeController> logger, IWantMyMummyContext con, UserManager<IWantMyMummyUser> tempUser)
        {
            context = con;
            _logger = logger;
            userManager = tempUser;
        }

        public IActionResult Index()
        {
            //HttpContext.Session.SetString(SessionName, "test"); (in case we want to use sessions)
            var role = (context.UserRoles
                .Where(r => r.UserId == userManager.GetUserId(User))
                .FirstOrDefault());

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }


            return View();


        }
        public IActionResult BurialList()
        {
            
            ViewBag.Id = userManager.GetUserId(User);
            var role = (context.UserRoles
                        .Where(r => r.UserId == userManager.GetUserId(User))
                        .FirstOrDefault());

            if (!(role is null))
            {
                ViewBag.Role = Int32.Parse(role.RoleId);
            }

            return View();
        }

        public IActionResult MummyJokes()
        {
            return View();
        }

        //researcher only
        public IActionResult ResearchPage()
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

        public IActionResult ResearchPageMummyInfo()
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
