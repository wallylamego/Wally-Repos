using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CicotiWebApp.Models;
using CicotiWebApp;

namespace WebAppFAM.Pages.ABC
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public IndexModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ActCostPeriod ActCostPeriod { get; set; }

        //This procedures runs Allocate Management Costs to the Correct Period
        public JsonResult OnPostAllocateCosts([FromBody] ActCostPeriod ActCostPeriod)
        {
            string PeriodNo = ActCostPeriod.Period;
            _context.Database.ExecuteSqlCommand("Step5_AllocateManAccCostsToActivities @p0",
                parameters: new[] { PeriodNo });
            return new JsonResult("OK");
        }


    }


}
