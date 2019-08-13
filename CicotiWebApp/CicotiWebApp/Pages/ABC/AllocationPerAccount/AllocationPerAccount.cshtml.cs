using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CicotiWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CicotiWebApp.Pages.ABC.AllocationPerAccount
{
    [Authorize]
    public class AllocationPerAccountModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;

        public AllocationPerAccountModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        
        public SelectList CostDriverSL { get; set; }
        public SelectList BranchSL { get; set; }
        public SelectList CategorySL { get; set; }
        public SelectList SubCategorySL { get; set; }
        public SelectList CostAllocationSL { get; set; }
        public SelectList AccountTypeSL { get; set; }

        
        public void PopulateCostDriverSL(object selectedCostDriver = null)
        {
            var CostDriverQuery = from s in _context.ActCostDrivers
                                      orderby s.Description
                                      select s;
            CostDriverSL = new SelectList(CostDriverQuery.AsNoTracking(),
                        "ActCostDriverID", "Description", selectedCostDriver);
        }
        public void PopulateBranchSL(object selectedBranch = null)
        {
            var BranchQuery = from s in _context.Branch
                                      orderby s.BranchName
                                      select s;
            BranchSL = new SelectList(BranchQuery.AsNoTracking(),
                        "BranchID", "BranchName", selectedBranch);
        }
        public void PopulateCategorySL(object selectedCategory = null)
        {
            var CategoryQuery = from s in _context.ActCostCategory
                                      orderby s.ActCostCategoryID
                                      select s;
            CategorySL = new SelectList(CategoryQuery.AsNoTracking(),
                        "ActCostCategoryID", "Description", selectedCategory);
        }
        public void PopulateSubCategorySL(object selectedSubCategory = null)
        {
            var SubCategoryQuery = from s in _context.ActSubCostCategory
                                      orderby s.Description
                                      select s;
            SubCategorySL = new SelectList(SubCategoryQuery.AsNoTracking(),
                        "ActCostSubCategoryID", "Description", selectedSubCategory);
        }
        public void PopulateCostAllocationSL(object selectedCostAllocation = null)
        {
            var CostAllocationQuery = from s in _context.ActCostAllocationSplits
                                      orderby s.Description
                                      select s;
            CostAllocationSL = new SelectList(CostAllocationQuery.AsNoTracking(),
                        "ActCostAllocationSplitID", "Description", selectedCostAllocation);
        }
        public void PopulateAccountTypeSL(object selectedAccountType = null)
        {
            var AccountTypeQuery = from s in _context.ActCostAccountType
                                      orderby s.Description
                                      select s;
            AccountTypeSL = new SelectList(AccountTypeQuery.AsNoTracking(),
                        "ActCostAccountTypeID", "Description", selectedAccountType);
        }

        [BindProperty] 
        public ActCostAccount Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int? AccountID)
        {
            Account = new ActCostAccount { };


            if (AccountID != null)
            {
                Account = await _context.ActCostAccount
                    .SingleOrDefaultAsync(m => m.ActCostAccountID == AccountID);
            }
            PopulateCostDriverSL();
            PopulateBranchSL();
            PopulateCategorySL();
            PopulateSubCategorySL();
            PopulateCostAllocationSL();
            PopulateAccountTypeSL();
            return Page();
        }
        #region Update Account Details
        //Updates the existing Account Details
        public async Task<IActionResult> OnPutUpdateAccount([FromBody] Models.ActCostAccount obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet")))
            {
                try
                {
                    _context.Attach(obj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Account Changes not saved." + d.InnerException.Message);
                }
            }
            return new JsonResult("Account Changes not saved.");
        }

        //Inserts a new Account with details
        public async Task<IActionResult> OnPostInsertAccount([FromBody] Models.ActCostAccount obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("Fleet")))
            {
                try
                {
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.ActCostAccountID; // Yes it's here
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Account Not Added." + d.InnerException.Message);
                }
            }

            else
            {
                return new JsonResult("Account Not Inserted");
            }

        }
        #endregion AccountUpdates

    }
}