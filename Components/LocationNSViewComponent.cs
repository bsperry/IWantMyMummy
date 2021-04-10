using IWantMyMummy.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWantMyMummy.Areas.Components
{
    public class LocationNSViewComponent : ViewComponent
    {
        private MummyContext context;
        public LocationNSViewComponent(MummyContext ctx)
        {
            context = ctx;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.LocationNS = RouteData?.Values["locationns"];
            return View(context.BurialSquare
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
