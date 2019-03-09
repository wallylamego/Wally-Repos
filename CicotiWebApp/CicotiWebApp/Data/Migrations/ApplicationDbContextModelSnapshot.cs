﻿// <auto-generated />
using System;
using CicotiWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CicotiWebApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CicotiWebApp.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Branch", b =>
                {
                    b.Property<int>("BranchID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BranchName");

                    b.Property<string>("ERPBranchID");

                    b.HasKey("BranchID");

                    b.ToTable("Branch");
                });

            modelBuilder.Entity("CicotiWebApp.Models.CostCentre", b =>
                {
                    b.Property<int>("CostCentreID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CostCentreName");

                    b.HasKey("CostCentreID");

                    b.ToTable("CostCentre");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Country", b =>
                {
                    b.Property<int>("CountryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("CountryID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("CicotiWebApp.Models.CustomerAccount", b =>
                {
                    b.Property<int>("CustomerAccountID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountDescription");

                    b.Property<string>("AccountNumber");

                    b.Property<string>("Terms");

                    b.HasKey("CustomerAccountID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("DepartmentID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Destination", b =>
                {
                    b.Property<int>("DestinationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Distance");

                    b.Property<int>("EndLocationID");

                    b.Property<int>("StartLocationID");

                    b.HasKey("DestinationID");

                    b.HasIndex("EndLocationID");

                    b.HasIndex("StartLocationID");

                    b.ToTable("Destinations");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Driver", b =>
                {
                    b.Property<int>("DriverID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("IDNumber")
                        .HasMaxLength(20);

                    b.Property<DateTime>("PDPExpiryDate");

                    b.Property<int>("SubContractorID");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("DriverID");

                    b.HasIndex("SubContractorID");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("CicotiWebApp.Models.DriveType", b =>
                {
                    b.Property<int>("DriveTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("DriveTypeID");

                    b.ToTable("DriveTypes");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BankAccount");

                    b.Property<int>("BranchID");

                    b.Property<int>("CostCentreID");

                    b.Property<int>("DepartmentID");

                    b.Property<string>("EmployeeNo");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("FirstName");

                    b.Property<int>("JobDescriptionID");

                    b.Property<string>("LastName");

                    b.Property<string>("PastelRepCode");

                    b.Property<string>("PastelRepName");

                    b.Property<int?>("ReportsToID");

                    b.Property<int>("SaleRepID");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("EmployeeID");

                    b.HasIndex("BranchID");

                    b.HasIndex("CostCentreID");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("JobDescriptionID");

                    b.HasIndex("ReportsToID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CicotiWebApp.Models.FuelType", b =>
                {
                    b.Property<int>("FuelTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("FuelTypeID");

                    b.ToTable("FuelTypes");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerAccountID");

                    b.Property<DateTime>("InvoiceDate");

                    b.Property<string>("InvoiceNumber");

                    b.Property<DateTime>("InvoicePrintDate");

                    b.Property<int?>("LoadID");

                    b.Property<int>("StatusID");

                    b.HasKey("InvoiceID");

                    b.HasIndex("CustomerAccountID");

                    b.HasIndex("LoadID");

                    b.HasIndex("StatusID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("CicotiWebApp.Models.InvoiceStatus", b =>
                {
                    b.Property<int>("InvoiceStatusID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("InvoiceID");

                    b.Property<int?>("LoadID");

                    b.Property<int>("StatusID");

                    b.Property<string>("UserID");

                    b.HasKey("InvoiceStatusID");

                    b.HasIndex("InvoiceID");

                    b.HasIndex("LoadID");

                    b.HasIndex("StatusID");

                    b.HasIndex("UserID");

                    b.ToTable("InvoiceStatus");
                });

            modelBuilder.Entity("CicotiWebApp.Models.InvoiceStatusRole", b =>
                {
                    b.Property<int>("InvoiceStatusRoleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleID");

                    b.Property<int>("StatusID");

                    b.HasKey("InvoiceStatusRoleID");

                    b.HasIndex("RoleID");

                    b.HasIndex("StatusID");

                    b.ToTable("InvoiceStatusRoles");
                });

            modelBuilder.Entity("CicotiWebApp.Models.JobDescription", b =>
                {
                    b.Property<int>("JobDescriptionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("JobDescriptionID");

                    b.ToTable("JobDescription");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Load", b =>
                {
                    b.Property<int>("LoadID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int?>("DestinationID");

                    b.Property<int>("DriverID");

                    b.Property<string>("LoadDate");

                    b.Property<string>("LoadName");

                    b.Property<int?>("LoadStatusID");

                    b.Property<bool>("ReverseDestinationID");

                    b.Property<string>("UserID");

                    b.Property<int>("VehicleID");

                    b.HasKey("LoadID");

                    b.HasIndex("DestinationID");

                    b.HasIndex("DriverID");

                    b.HasIndex("LoadStatusID");

                    b.HasIndex("UserID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Loads");
                });

            modelBuilder.Entity("CicotiWebApp.Models.LoadStatus", b =>
                {
                    b.Property<int>("LoadStatusID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("LoadStatusID");

                    b.ToTable("LoadStatus");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("GPSCoordinates");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("ProvinceID");

                    b.HasKey("LocationID");

                    b.HasIndex("ProvinceID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Make", b =>
                {
                    b.Property<int>("MakeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MakeName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("MakeID");

                    b.ToTable("Make");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Model", b =>
                {
                    b.Property<int>("ModelID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DriveTypeID");

                    b.Property<int?>("FuelTypeID");

                    b.Property<int?>("MakeID");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("NoOfWheels");

                    b.Property<int?>("VehicleTypeID");

                    b.HasKey("ModelID");

                    b.HasIndex("DriveTypeID");

                    b.HasIndex("FuelTypeID");

                    b.HasIndex("MakeID");

                    b.HasIndex("VehicleTypeID");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Principle", b =>
                {
                    b.Property<int>("PrincipleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PastelName")
                        .IsRequired();

                    b.Property<string>("PrincipalName")
                        .IsRequired();

                    b.HasKey("PrincipleID");

                    b.ToTable("Principle");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Province", b =>
                {
                    b.Property<int>("ProvinceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryID");

                    b.Property<string>("ProvinceName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.HasKey("ProvinceID");

                    b.HasIndex("CountryID");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("CicotiWebApp.Models.SKU", b =>
                {
                    b.Property<int>("SKUID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<double>("CubicMetrePerPallet");

                    b.Property<double>("CubicMetrePerUnit");

                    b.Property<string>("Description");

                    b.Property<string>("UOM");

                    b.Property<string>("UOMConversionFactor");

                    b.Property<double>("UnitsPerPallets");

                    b.Property<double>("WeightPerUnit");

                    b.HasKey("SKUID");

                    b.ToTable("SKUs");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Status", b =>
                {
                    b.Property<int>("StatusID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<double>("HrsInStatus");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("SortOrder");

                    b.HasKey("StatusID");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("CicotiWebApp.Models.SubContractor", b =>
                {
                    b.Property<int>("SubContractorID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("SubContractorID");

                    b.ToTable("SubContractor");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AcquisitionDate");

                    b.Property<double>("AcquistionCost");

                    b.Property<int?>("BranchID");

                    b.Property<int?>("CostCentreID");

                    b.Property<double>("DepreciationMonths");

                    b.Property<int?>("EmployeeID");

                    b.Property<string>("FixedAssetsNumber");

                    b.Property<int?>("MakeID");

                    b.Property<int?>("ModelID");

                    b.Property<string>("RegNumberABB");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int?>("SubContractorID");

                    b.Property<int?>("VehiclePurposeID");

                    b.Property<int>("VehicleTypeID");

                    b.HasKey("VehicleID");

                    b.HasIndex("BranchID");

                    b.HasIndex("CostCentreID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("MakeID");

                    b.HasIndex("ModelID");

                    b.HasIndex("SubContractorID");

                    b.HasIndex("VehiclePurposeID");

                    b.HasIndex("VehicleTypeID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("CicotiWebApp.Models.VehiclePurpose", b =>
                {
                    b.Property<int>("VehiclePurposeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.HasKey("VehiclePurposeID");

                    b.ToTable("VehiclePurpose");
                });

            modelBuilder.Entity("CicotiWebApp.Models.VehicleType", b =>
                {
                    b.Property<int>("VehicleTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("VehicleTypeID");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Destination", b =>
                {
                    b.HasOne("CicotiWebApp.Models.Location", "EndLocation")
                        .WithMany()
                        .HasForeignKey("EndLocationID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Location", "StartLocation")
                        .WithMany()
                        .HasForeignKey("StartLocationID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CicotiWebApp.Models.Driver", b =>
                {
                    b.HasOne("CicotiWebApp.Models.SubContractor", "SubContractor")
                        .WithMany()
                        .HasForeignKey("SubContractorID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CicotiWebApp.Models.Employee", b =>
                {
                    b.HasOne("CicotiWebApp.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.CostCentre", "CostCentre")
                        .WithMany()
                        .HasForeignKey("CostCentreID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.JobDescription", "JobDescription")
                        .WithMany()
                        .HasForeignKey("JobDescriptionID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Employee", "ReportsTo")
                        .WithMany()
                        .HasForeignKey("ReportsToID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CicotiWebApp.Models.Invoice", b =>
                {
                    b.HasOne("CicotiWebApp.Models.CustomerAccount", "CustomerAccount")
                        .WithMany()
                        .HasForeignKey("CustomerAccountID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Load", "Load")
                        .WithMany("Invoices")
                        .HasForeignKey("LoadID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CicotiWebApp.Models.InvoiceStatus", b =>
                {
                    b.HasOne("CicotiWebApp.Models.Invoice", "Invoice")
                        .WithMany("InvoiceStatuses")
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Load", "Load")
                        .WithMany()
                        .HasForeignKey("LoadID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CicotiWebApp.Models.InvoiceStatusRole", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CicotiWebApp.Models.Load", b =>
                {
                    b.HasOne("CicotiWebApp.Models.Destination", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.LoadStatus", "LoadStatus")
                        .WithMany()
                        .HasForeignKey("LoadStatusID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CicotiWebApp.Models.Location", b =>
                {
                    b.HasOne("CicotiWebApp.Models.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CicotiWebApp.Models.Model", b =>
                {
                    b.HasOne("CicotiWebApp.Models.DriveType", "DriveType")
                        .WithMany()
                        .HasForeignKey("DriveTypeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.FuelType", "FuelType")
                        .WithMany()
                        .HasForeignKey("FuelTypeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Make", "Make")
                        .WithMany()
                        .HasForeignKey("MakeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.VehicleType", "VehicleType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CicotiWebApp.Models.Province", b =>
                {
                    b.HasOne("CicotiWebApp.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CicotiWebApp.Models.Vehicle", b =>
                {
                    b.HasOne("CicotiWebApp.Models.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.CostCentre", "CostCentre")
                        .WithMany()
                        .HasForeignKey("CostCentreID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Make", "Make")
                        .WithMany()
                        .HasForeignKey("MakeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.SubContractor", "SubContractor")
                        .WithMany()
                        .HasForeignKey("SubContractorID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.VehiclePurpose", "VehiclePurpose")
                        .WithMany()
                        .HasForeignKey("VehiclePurposeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CicotiWebApp.Models.VehicleType", "VechileType")
                        .WithMany()
                        .HasForeignKey("VehicleTypeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CicotiWebApp.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CicotiWebApp.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CicotiWebApp.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CicotiWebApp.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
