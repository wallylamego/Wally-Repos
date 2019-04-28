using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.Users
{
    public class UserRolesModel : PageModel
    {
        public SelectList RoleNameSL { get; set; }

        [BindProperty]
        public String Role { get; set; }

        [BindProperty]
        public ApplicationUser UserItem { get; set;}

        private readonly RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public UserRolesModel(RoleManager<IdentityRole> roleManager,
            CicotiWebApp.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _context = context;
            _userManager = userManager;
        }
       
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {
            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "Description",
                out bool SortDir, out string SortBy);

            ApplicationUser Currentuser = _context.Users.FirstOrDefault(u => u.Id == Model.UserID);

            var RolesQuery = (from user in _context.UserRoles
                                  join role in _context.Roles on user.RoleId equals
                                  role.Id
                                  where user.UserId == Currentuser.Id
                                  select new
                                  {
                                     RoleID= role.Id,
                                     RoleName = role.Name
                                  });

            totalResultsCount = RolesQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                RolesQuery = RolesQuery
                        .Where(
                v => v.RoleName.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = RolesQuery.Count();
            }
            var Result = await RolesQuery
                        .Skip(Model.start)
                        .Take(Model.length)
                        .OrderBy(SortBy, SortDir)
                        .ToListAsync();

            var value = new
            {
                // this is what datatables wants sending back
                draw = Model.draw,
                recordsTotal = totalResultsCount,
                recordsFiltered = filteredResultsCount,
                data = Result
            };
            return new JsonResult(value);
        }

        public IActionResult OnGet(string UserID)
        {
            UserItem = _context.Users.FirstOrDefault(u => u.Id == UserID);
            RoleNameSL = new SelectList(_roleManager.Roles,
                       "Name", "Name");
            return Page();
        }

        public async Task<JsonResult> OnPostAddRole([FromBody] UserItem User)
        {
            try
            {
                UserItem = _context.Users.FirstOrDefault(u => u.Id == User.UserID);
                if(await _userManager.IsInRoleAsync(UserItem, User.RoleName))
                {
                    return new JsonResult("User is in this role Already");
                }
                await _userManager.AddToRoleAsync(UserItem, User.RoleName);
                return new JsonResult("You were successfull");
            }
            catch(Exception e)
            {
                return new JsonResult("You were unsuccessfull." + e.InnerException.Message);
            }
            
        }

        public async Task<IActionResult> OnDeleteDelete([FromBody] UserItem obj)
        {

            if (obj != null && HttpContext.User.IsInRole("Admin"))
            {
                try
                {
                    ApplicationUser user = _context.Users.FirstOrDefault(u => u.Id == obj.UserID);
                    var identityUserRole = _context.UserRoles.FirstOrDefault(
                        u => u.UserId == obj.UserID && u.RoleId == obj.RoleID);
                    _context.UserRoles.Remove(identityUserRole);
                    await _context.SaveChangesAsync();
                    return new JsonResult("User Role removed successfully");
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("User Role not removed." + d.InnerException.Message);
                }
            }
            else
            {
                return new JsonResult("Vehicle not removed.");
            }
        }


    }
}