using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CicotiWebApp.Models;

namespace CicotiWebApp.Pages.VehicleTypes
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
        public VehicleType VehicleType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet"))
            {
                _context.VehicleTypes.Add(VehicleType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}