using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CicotiWebApp.Areas.Identity.Pages.Account
{
    public class AddUserRolesModel : PageModel
    {
        public SelectList RoleNameSL { get; set; }

        [BindProperty]
        public String Role { get; set; }

        private readonly RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> _roleManager;

        public AddUserRolesModel(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public void OnGet()
        {
                RoleNameSL = new SelectList(_roleManager.Roles,
                      "Name", "Name");
        }
    }
}