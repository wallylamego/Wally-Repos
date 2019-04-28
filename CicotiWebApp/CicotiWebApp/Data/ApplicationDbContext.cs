using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CicotiWebApp.Models;
using CicotiWebApp.SQLViews;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CicotiWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.SetCommandTimeout(120);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        //public DbSet<Employee> Employee { get; set; }
        public DbSet<JobDescription> JobDescription { get; set; }
        public DbSet<CostCentre> CostCentre { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Make> Make { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<DriveType> DriveTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Principle> Principle { get; set; }
        public DbSet<Silo> Silo { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<CustomerAccount> Accounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLine { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<InvoiceProductType> InvoiceProductType { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatus { get; set;}
        public DbSet<SubContractor> SubContractor { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclePurpose> VehiclePurpose { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set;}
        public DbSet<Driver> Drivers { get; set;}
        public DbSet<Load> Loads { get; set; }
        public DbSet<LoadStatus> LoadStatus { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<SKU> SKUs { get; set;}
        public DbSet<ActCostChannel> ActCostChannel { get; set;}
        public DbSet<ActCostWarehouse> ActCostWarehouse {get; set;}

        public DbSet<InvoiceStatusRole> InvoiceStatusRoles { get; set; }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }

        public DbSet<VehicleComment> VehicleComments { get; set; }
        public DbSet<VehicleStatus> VehicleStatus { get; set; }

        public DbSet<UOM> UOM { get; set; }
        public DbSet<StockCountItem> StockCountItems { get; set; }
        public DbSet<StockQuality> StockQuality { get; set; }

        public DbSet<ActCostAllocationSplit> ActCostAllocationSplits { get; set; }
        public DbSet<ActCostDriver> ActCostDrivers { get; set; }
        public DbSet<ActCostPeriod> ActCostPeriods { get; set; }
        public DbSet<ActCostTransaction> ActCostTransactions { get; set; }
        public DbSet<ActCostSiloAllocation> ActCostSiloAllocations { get; set; }
        public DbSet<ActCostAccount> ActCostAccount { get; set; }
        public DbSet<ActCostAccountBalance> ActCostAccountBalance { get; set;}
        public DbSet<ActCostCategory> ActCostCategory { get; set; }
        public DbSet<ActCostSubCategory> ActSubCostCategory { get; set; }
        public DbSet<ActCostBalanceAllocation> ActCostBalanceAllocation { get; set; }
        public DbSet<ActCostInsuranceType> ActCostInsuranceType { get; set; }
        public DbSet<ActCostCashCollectionCost> ActCostCashCollectionCost { get; set; }
        public DbSet<ActCostAccountPerPrinciple> ActCostAccountPerPrinciple { get; set; }
        public DbSet<ActCostAccountType> ActCostAccountType { get; set; }
        public DbSet<ActCostPrincipleBalance> ActCostPrincipleBalance { get; set; }
        public DbSet<ActCostPayrollField> ActCostPayrollFields { get; set; }
        public DbSet<ActCostAccountAmtPrinciple> ActCostAccountAmtPrinciple { get; set; }
        public DbSet<ActCostInvestmentType> ActCostInvestmentType { get; set; }
        public DbSet<ActCostInvestment> ActCostInvestment { get; set; }
        public DbSet<ActCostFixedAssetAccount> ActCostFixedAssetAccount { get; set; }
        public DbSet<ActCostAlloctedSpacePerPrinciple> ActCostAlloctedSpacePerPrinciple { get; set; }

        public DbSet<FuelPrice> FuelPrice { get; set; }
        public DbSet<VehicleKm> VehicleKms { get; set;}

        public DbSet<Currency> Currency { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<InterCompany> InterCompany { get; set; }
        public DbQuery<VwDeliveryStatusDetail> VwDeliveryStatusDetails { get; set; }
        public DbQuery<VwDeliveryStatsSummary> VwDeliveryStatusSummaryPerMonth_2 { get; set; }
        public DbQuery<VwStockCountSummary> VwStockCountSummary { get; set; }
    }
}
