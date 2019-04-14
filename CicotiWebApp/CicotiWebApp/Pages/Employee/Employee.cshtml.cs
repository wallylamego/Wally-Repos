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

namespace CicotiWebApp.Pages.Employee
{
    [Authorize]
    public class EmployeeModel : PageModel
    {
        private readonly CicotiWebApp.Data.ApplicationDbContext _context;
        private EmployeeBusinessLayer _empBusLayer;

        public EmployeeModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
            _empBusLayer = new EmployeeBusinessLayer();
        }

        [BindProperty]
        public CicotiWebApp.Models.Employee Employee { get; set; }

        public SelectList JobDescriptionSL { get; set; }
        public SelectList BranchSL { get; set; }
        public SelectList CostCentreSL { get; set; }
        public SelectList VehiclePurposeSL { get; set; }
        public SelectList DepartmentSL { get; private set; }

        public void PopulateJobDescriptionSL(object selectedJobDescription = null)
        {
            var JobDescriptionsQuery = from v in _context.JobDescription
                                       orderby v.Description
                                       select v;
            JobDescriptionSL = new SelectList(JobDescriptionsQuery.AsNoTracking(),
                        "JobDescriptionID", "Description", selectedJobDescription);
        }
        public void PopulateBranchTypeSL(object selectedBranch = null)
        {
            var BranchQuery = from b in _context.Branch
                              orderby b.BranchName
                              select b;
            BranchSL = new SelectList(BranchQuery.AsNoTracking(),
                        "BranchID", "BranchName", selectedBranch);
        }
        public void PopulateCostCentreSL(object selectedCostCentre = null)
        {
            var CostCentreQuery = from c in _context.CostCentre
                                  orderby c.CostCentreName
                                  select c;
            CostCentreSL = new SelectList(CostCentreQuery.AsNoTracking(),
                        "CostCentreID", "CostCentreName", selectedCostCentre);
        }
        public void PopulateDepartmentSL(object selectedDepartment = null)
        {
            var DepartmentQuery = from c in _context.Department
                                  orderby c.DepartmentName
                                  select c;
            DepartmentSL = new SelectList(DepartmentQuery.AsNoTracking(),
                        "DepartmentID", "DepartmentName", selectedDepartment);
        }

        public async Task<IActionResult> OnGetAsync(int? EmployeeID)
        {
            Employee = new Models.Employee { };
            PopulateJobDescriptionSL();
            PopulateBranchTypeSL();
            PopulateCostCentreSL();
            PopulateDepartmentSL();

            if (EmployeeID != null)
            {
                Employee = await _context.Employees
                    .Include(v => v.Branch)
                    .Include(c => c.CostCentre)
                    .Include(e => e.JobDescription)
                    .Include(m => m.Department)
                    .SingleOrDefaultAsync(m => m.EmployeeID == EmployeeID);
            }
            return Page();
        }

        #region Update Employee Details
        //Inserts a new Employee with details
        public async Task<IActionResult> OnPostInsertEmployee([FromBody] Models.Employee obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("HR"))) 
            {
                try
                {
                    obj.ActCostAllocationSplitID = _empBusLayer.FindAllocationSplitID(obj.CostCentreID, obj.DepartmentID);
                    if (obj.EmployeeID == 0)
                    {
                        _context.Add(obj);
                    }
                    else
                    {
                        _context.Attach(obj).State = EntityState.Modified;
                    }
                    
                    await _context.SaveChangesAsync();
                    var value = new
                    {
                        msg = "Employee Successfully Updated",
                        employee = obj
                    };
                    return new JsonResult(value);
                }
                catch (DbUpdateException d)
                {
                    var value = new
                    {
                        msg = "Employee Changes not Saved" + d.InnerException.Message,
                        employee = obj
                    };
                    return new JsonResult(value);
                }
            }

            else
            {
                var value = new
                {
                    msg = "Employee Changes not Saved",
                    employee = obj
                };
                return new JsonResult(value);
            }

        }
        #endregion EmployeeUpdates

    }
}