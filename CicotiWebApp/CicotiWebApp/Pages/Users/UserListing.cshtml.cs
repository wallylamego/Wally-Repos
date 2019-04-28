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

namespace CicotiWebApp.Pages.Users
{
    public class UserListing : PageModel
    {
        public SelectList RoleNameSL { get; set; }

        [BindProperty]
        public String Role { get; set; }

        private readonly RoleManager<Microsoft.AspNetCore.Identity.IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public UserListing(RoleManager<IdentityRole> roleManager,
            CicotiWebApp.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            _context = context;
            _userManager = userManager;
        }
        public void OnGet()
        {
               
        }
        public async Task<JsonResult> OnPostPaging([FromForm] DataTableAjaxPostModel Model)
        {
            int filteredResultsCount = 0;
            int totalResultsCount = 0;

            DataTableAjaxPostModel.GetOrderByParameters(Model.order, Model.columns, "Description",
                out bool SortDir, out string SortBy);

            

            var UserQuery = (from user in _context.Users
                                  select new
                                  {
                                     Id = user.Id,
                                     UserName= user.UserName,
                                     user.Email
                                  });

            totalResultsCount = UserQuery.Count();
            filteredResultsCount = totalResultsCount;

            if (!string.IsNullOrEmpty(Model.search.value))
            {
                UserQuery = UserQuery
                        .Where(
                v => v.UserName.ToLower().Contains(Model.search.value.ToLower())
                       );

                filteredResultsCount = UserQuery.Count();
            }
            var Result = await UserQuery
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
    }
}