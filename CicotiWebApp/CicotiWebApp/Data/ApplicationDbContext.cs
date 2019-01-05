using System;
using System.Collections.Generic;
using System.Text;
using CicotiWebApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CicotiWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Principle> Principle { get; set; }
        public DbSet<SalesRep> SalesRep { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<CustomerAccount> Accounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatus { get; set;}
    }
}
