using IWantMyMummy.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWantMyMummy.Models.ViewModels
{
    public class UsersRolesViewModel
    {
        public IWantMyMummyUser mummyUser { get; set; }

        public IdentityUserRole<string>? identityUserRole { get; set; }
                                                                        

        public IdentityRole<string>? identityRole { get; set; }
    }
}
