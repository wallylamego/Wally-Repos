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
        public JsonResult OnPostTransCount([FromBody] ActCostPeriod ActCostPeriod)
        {
            string PeriodNo = ActCostPeriod.Period;

            if (HttpContext.User.IsInRole("Admin"))
            {
                if (!PeriodExists(PeriodNo))
                {
                    return new JsonResult("This period does not exist. Update not Run");
                }
                try
                {
                    _context.Database.ExecuteSqlCommand("Step1_ActCostTransactionCount @p0",
                    parameters: new[] { PeriodNo });
                    return new JsonResult("Transaction Count Updated Successfully for: " + ActCostPeriod.Period);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return new JsonResult("Update not run. Error Message is: " + e.InnerException.Message);
                }
            }
            return new JsonResult("You do not rights to run this update");

        }
        //This procedures Allocates Sales and Cost of Sales to the Correct Period
        public JsonResult OnPostSalesUpdate([FromBody] ActCostPeriod ActCostPeriod)
        {
            string PeriodNo = ActCostPeriod.Period;

            if (HttpContext.User.IsInRole("Admin"))
            {
                if (!PeriodExists(PeriodNo))
                {
                    return new JsonResult("This period does not exist. Update not Run");
                }
                try
                {
                    _context.Database.ExecuteSqlCommand("Step1_SalesUpdatePerPeriod @p0",
                    parameters: new[] { PeriodNo });
                    return new JsonResult("Sales Updated Successfully for " + ActCostPeriod.Period);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return new JsonResult("Update not run. Error Message is: " + e.InnerException.Message);
                }
            }
            return new JsonResult("You do not rights to run this update");

        }
        //This procedures Archives the Employee Table for the Correct Period
        public JsonResult OnPostEmloyeeUpdate([FromBody] ActCostPeriod ActCostPeriod)
        {
            string PeriodNo = ActCostPeriod.Period;

            if (HttpContext.User.IsInRole("Admin"))
            {
                if (!PeriodExists(PeriodNo))
                {
                    return new JsonResult("This period does not exist. Update not Run");
                }
                try
                {
                    _context.Database.ExecuteSqlCommand("Step2_EmployeeArchive @p0",
                    parameters: new[] { PeriodNo });
                    return new JsonResult("Employee Table Archived Updated Successfully for " + ActCostPeriod.Period);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return new JsonResult("Update not run. Error Message is: " + e.InnerException.Message);
                }
            }
            return new JsonResult("You do not rights to run this update");

        }
        //This procedures Archives the Vehicle Table for the Correct Period
        public JsonResult OnPostVehicleUpdate([FromBody] ActCostPeriod ActCostPeriod)
        {
            string PeriodNo = ActCostPeriod.Period;

            if (HttpContext.User.IsInRole("Admin"))
            {
                if (!PeriodExists(PeriodNo))
                {
                    return new JsonResult("This period does not exist. Update not Run");
                }
                try
                {
                    _context.Database.ExecuteSqlCommand("Step2_VehicleArchive @p0",
                    parameters: new[] { PeriodNo });
                    return new JsonResult("Vehicle Archive Updated Successfully for " + ActCostPeriod.Period);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return new JsonResult("Update not run. Error Message is: " + e.InnerException.Message);
                }
            }
            return new JsonResult("You do not rights to run this update");

        }
        //This procedures Allocates Pallets per Principle to the Correct Period
        public JsonResult OnPostPallets([FromBody] ActCostPeriod ActCostPeriod)
        {
            string PeriodNo = ActCostPeriod.Period;

            if (HttpContext.User.IsInRole("Admin"))
            {
                if (!PeriodExists(PeriodNo))
                {
                    return new JsonResult("This period does not exist. Update not Run");
                }
                try
                {
                    _context.Database.ExecuteSqlCommand("Step2_PalletsOnHand @p0",
                    parameters: new[] { PeriodNo });
                    return new JsonResult("Pallets On Hand Updated Successfully for " + ActCostPeriod.Period);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return new JsonResult("Update not run. Error Message is: " + e.InnerException.Message);
                }
            }
            return new JsonResult("You do not rights to run this update");

        }
        //This procedures calculate MonthEnd Balance Movements to the Correct Period
        public JsonResult OnPostAccBalanceUpdate([FromBody] ActCostPeriod ActCostPeriod)
        {
            string PeriodNo = ActCostPeriod.Period;

            if (HttpContext.User.IsInRole("Admin"))
            {
                if (!PeriodExists(PeriodNo))
                {
                    return new JsonResult("This period does not exist. Update not Run");
                }
                try
                {
                    _context.Database.ExecuteSqlCommand("Step3_AccBalanceMovementUpdate @p0",
                    parameters: new[] { PeriodNo });
                    return new JsonResult("Balance Movements Updated Successfully for " + ActCostPeriod.Period);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return new JsonResult("Update not run. Error Message is: " + e.InnerException.Message);
                }
            }
            return new JsonResult("You do not rights to run this update");

        }
        //This procedures allocates Staff Costs to the Correct Period
        public JsonResult OnPostStaffPerPrinciple([FromBody] ActCostPeriod ActCostPeriod)
        {
            string PeriodNo = ActCostPeriod.Period;

            if (HttpContext.User.IsInRole("Admin"))
            {
                if (!PeriodExists(PeriodNo))
                {
                    return new JsonResult("This period does not exist. Update not Run");
                }
                try
                {
                    _context.Database.ExecuteSqlCommand("Step4_ActCostTableStaffAllocation @p0",
                    parameters: new[] { PeriodNo });
                    return new JsonResult("Staff Costs Updated Successfully for " + ActCostPeriod.Period);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return new JsonResult("Update not run. Error Message is: " + e.InnerException.Message);
                }
            }
            return new JsonResult("You do not rights to run this update");

        }
        //This procedures allocates Vehicle Costs to the Correct Period
        public JsonResult OnPostVehicleAllocation([FromBody] ActCostPeriod ActCostPeriod)
        {
            string PeriodNo = ActCostPeriod.Period;

            if (HttpContext.User.IsInRole("Admin"))
            {
                if (!PeriodExists(PeriodNo))
                {
                    return new JsonResult("This period does not exist. Update not Run");
                }
                try
                {
                    _context.Database.ExecuteSqlCommand("Step4_ActCostTableVehicleAllocation @p0",
                    parameters: new[] { PeriodNo });
                    return new JsonResult("Vehicle Costs Allocated Updated Successfully for " + ActCostPeriod.Period);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return new JsonResult("Update not run. Error Message is: " + e.InnerException.Message);
                }
            }
            return new JsonResult("You do not rights to run this update");

        }
        //This procedures runs Allocate Management Costs to the Correct Period
        public JsonResult OnPostAllocateCosts([FromBody] ActCostPeriod ActCostPeriod)
        {
            string PeriodNo = ActCostPeriod.Period;
            
            if (HttpContext.User.IsInRole("Admin"))
            {
                if (!PeriodExists(PeriodNo))
                {
                    return new JsonResult("This period does not exist. Update not Run");
                }
                try
                {
                    _context.Database.ExecuteSqlCommand("Step5_AllocateManAccCostsToActivities @p0",
                    parameters: new[] { PeriodNo });
                    return new JsonResult("Allocated Costs Updated Successfully for " + ActCostPeriod.Period);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return new JsonResult("Update not run. Error Message is: " + e.InnerException.Message);
                }
            }
            return new JsonResult("You do not rights to run this update");
            
        }
        //This procedures allocates Debtors to Principles to the Correct Period
        public JsonResult OnPostAllocateDebtors([FromBody] ActCostPeriod ActCostPeriod)
        {
            string PeriodNo = ActCostPeriod.Period;

            if (HttpContext.User.IsInRole("Admin"))
            {
                if (!PeriodExists(PeriodNo))
                {
                    return new JsonResult("This period does not exist. Update not Run");
                }
                try
                {
                    _context.Database.ExecuteSqlCommand("Step6_CreateDebtorsSplitByPrincipal @p0",
                    parameters: new[] { PeriodNo });
                    return new JsonResult("Debtors Updated Successfully for " + ActCostPeriod.Period);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return new JsonResult("Update not run. Error Message is: " + e.InnerException.Message);
                }
            }
            return new JsonResult("You do not rights to run this update");

        }
        //This procedures allocates Investments: Debtors, Stock to the Correct Period
        public JsonResult OnPostInvestment([FromBody] ActCostPeriod ActCostPeriod)
        {
            string PeriodNo = ActCostPeriod.Period;

            if (HttpContext.User.IsInRole("Admin"))
            {
                if (!PeriodExists(PeriodNo))
                {
                    return new JsonResult("This period does not exist. Update not Run");
                }
                try
                {
                    _context.Database.ExecuteSqlCommand("Step7_CreateInvestmentTable @p0",
                    parameters: new[] { PeriodNo });
                    return new JsonResult("Investment Updated Successfully for " + ActCostPeriod.Period);
                }
                catch (DbUpdateConcurrencyException e)
                {
                    return new JsonResult("Update not run. Error Message is: " + e.InnerException.Message);
                }
            }
            return new JsonResult("You do not rights to run this update");

        }

        private bool PeriodExists(string periodNo)
        {
            return _context.ActCostPeriods.Any(e => e.Period == periodNo);
        }


    }


}
