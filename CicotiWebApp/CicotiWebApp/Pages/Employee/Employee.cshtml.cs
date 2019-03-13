﻿using System;
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

        public EmployeeModel(CicotiWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
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
        //Updates the existing Vehicle
        public async Task<IActionResult> OnPutUpdateEmployee([FromBody] Models.Employee obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("HR")))
                {
                try
                {
                    _context.Attach(obj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Employee Changes not saved." + d.InnerException.Message);
                }
            }
            return new JsonResult("Employee Changes not saved.");
        }

        //Inserts a new Employee with details
        public async Task<IActionResult> OnPostInsertEmployee([FromBody] Models.Employee obj)
        {
            if (obj != null && (HttpContext.User.IsInRole("Admin") || HttpContext.User.IsInRole("HR"))) 
            {
                try
                { 
                    _context.Add(obj);
                    await _context.SaveChangesAsync();
                    int id = obj.EmployeeID; // Yes it's here
                    return new JsonResult(obj);
                }
                catch (DbUpdateException d)
                {
                    return new JsonResult("Employee Not Added." + d.InnerException.Message);
                }
            }

            else
            {
                return new JsonResult("Insert Destination was null");
            }

        }
        #endregion EmployeeUpdates

    }
}