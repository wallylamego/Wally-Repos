﻿// <auto-generated />
using System;
using CicotiWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CicotiWebApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190205154903_InvoiceStatusRole")]
    partial class InvoiceStatusRole
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("CicotiWebApp.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("EmployeeNo")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("EmployeeID");

                    b.ToTable("Employee");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Employee");
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

            modelBuilder.Entity("CicotiWebApp.Models.Load", b =>
                {
                    b.Property<int>("LoadID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedUtc")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("DriverID");

                    b.Property<string>("LoadDate");

                    b.Property<string>("LoadName");

                    b.Property<string>("UserID");

                    b.Property<int>("VehicleID");

                    b.HasKey("LoadID");

                    b.HasIndex("DriverID");

                    b.HasIndex("UserID");

                    b.HasIndex("VehicleID");

                    b.ToTable("Loads");
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

            modelBuilder.Entity("CicotiWebApp.Models.SKU", b =>
                {
                    b.Property<int>("SKUID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<double>("CubicMetrePerPallet");

                    b.Property<double>("CubicMetrePerUnit");

                    b.Property<string>("Description");

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

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<int>("SubContractorID");

                    b.Property<int>("VehicleTypeID");

                    b.HasKey("VehicleID");

                    b.HasIndex("SubContractorID");

                    b.HasIndex("VehicleTypeID");

                    b.ToTable("Vehicles");
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

            modelBuilder.Entity("CicotiWebApp.Models.SalesRep", b =>
                {
                    b.HasBaseType("CicotiWebApp.Models.Employee");

                    b.Property<string>("PastelRepCode")
                        .IsRequired();

                    b.Property<string>("PastelRepName")
                        .IsRequired();

                    b.Property<int>("SalesRepID");

                    b.ToTable("SalesRep");

                    b.HasDiscriminator().HasValue("SalesRep");
                });

            modelBuilder.Entity("CicotiWebApp.Models.Driver", b =>
                {
                    b.HasOne("CicotiWebApp.Models.SubContractor", "SubContractor")
                        .WithMany()
                        .HasForeignKey("SubContractorID")
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
                    b.HasOne("CicotiWebApp.Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverID")
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

            modelBuilder.Entity("CicotiWebApp.Models.Vehicle", b =>
                {
                    b.HasOne("CicotiWebApp.Models.SubContractor", "SubContractor")
                        .WithMany()
                        .HasForeignKey("SubContractorID")
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
