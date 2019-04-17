using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.SKU
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public CreateModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CicotiWebApp.Models.SKU SKU { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (HttpContext.User.IsInRole("Fleet") || (HttpContext.User.IsInRole("Admin")) || (HttpContext.User.IsInRole("WareHouse")))
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.SKUs.Add(SKU);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            return new JsonResult("You do not have access to change this page");
        }
    }
}