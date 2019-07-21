using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CicotiWebApp.Data;
using CicotiWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace CicotiWebApp
{
    public class WorkFlowRule
    {
        
        List<string>_roleList { get; set; }
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public  WorkFlowRule (
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //check if roles can process that new status
        //pass in a user and the process he wishes to update to
        public async Task<Boolean> WorkFlowRuleRole(int InvoiceStatusID,HttpContext httpContext)
        {
            ApplicationUser user = await _userManager.GetUserAsync(httpContext.User);
            var UserRoles = await _userManager.GetRolesAsync(user);
            var RolesList = _context.Roles.ToList();

            string userRoleId;
            Models.InvoiceStatusRole InvoiceStatusRole;
            foreach (string RoleName in UserRoles)
            {
                //get the roleId for this userRole
                userRoleId = RolesList.FirstOrDefault(r => r.Name == RoleName).Id;
                //Check this roleId
                InvoiceStatusRole =  _context.InvoiceStatusRoles.FirstOrDefault(s => s.RoleID == userRoleId &&
                                InvoiceStatusID == s.StatusID);
                if (InvoiceStatusRole != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }



        //check if sequence follows or if sequence goes into reverse
        //status 1 followed up status 2 followed by status 3 e.t.c
        public Boolean WorFlowRuleSequence(int NewInvoiceStatusID, int CurrentInvoiceStatusID)
        {
            Status NewInvoiceStatus = _context.Status.FirstOrDefault(sn => sn.StatusID == NewInvoiceStatusID);
            Status CurrentInvoiceStatus = _context.Status.FirstOrDefault(sn => sn.StatusID == CurrentInvoiceStatusID);

            if (NewInvoiceStatus.SortOrder == CurrentInvoiceStatus.SortOrder + 1 ||
                NewInvoiceStatus.SortOrder == CurrentInvoiceStatus.SortOrder - 1 ||
                NewInvoiceStatus.SortOrder == 6 ||
                NewInvoiceStatus.Name.ToUpper().Contains("CANCEL"))
            {
                return true;
            }
            return false;
        }

        public async Task<Boolean> WorkFlowCheck(int NewInvoiceStatusID, int CurrentInvoiceStatusID, HttpContext httpContext)
        {
            // await WorFlowRuleSequence(NewInvoiceStatusID, CurrentInvoiceStatusID)
            ApplicationUser user = await _userManager.GetUserAsync(httpContext.User);
            if (await WorkFlowRuleRole(NewInvoiceStatusID, httpContext) &&
                WorFlowRuleSequence(NewInvoiceStatusID, CurrentInvoiceStatusID))
            {
                return true;
            }
            return false;
        }

        //present a list of allowable statuses to the user based on his roles
        //where the use

        public async Task<SelectList> getAuthorisedStatusAsync(HttpContext httpContext, object selectedStatus = null )
        {
            SelectList StatusSL;

            List <Status> StatusList = new List<Status>();
            ApplicationUser user = await _userManager.GetUserAsync(httpContext.User);

            var UserRoles = await _userManager.GetRolesAsync(user);
            var RolesList = _context.Roles.ToList();

            List<SKU> UserStatusList = new List<SKU>();

            string userRoleId;
            foreach (string RoleName in UserRoles)
            {
                //get the roleId for this userRole
                userRoleId = RolesList.FirstOrDefault(r => r.Name == RoleName).Id;
                //Check this roleId
                List<InvoiceStatusRole> InvoiceStatusRoleList =
                      _context.InvoiceStatusRoles.Include(s=>s.Status)
                      .Where(r => r.RoleID == userRoleId).ToList();
                Status statusItem;
                foreach(InvoiceStatusRole invStatusRole in InvoiceStatusRoleList)
                {
                    statusItem = new Status();
                    statusItem = invStatusRole.Status;
                    StatusList.Add(statusItem);
                }
            }
            StatusSL = new SelectList(StatusList,
                        "StatusID", "Name", selectedStatus);
            return StatusSL;
        }
    }
}
