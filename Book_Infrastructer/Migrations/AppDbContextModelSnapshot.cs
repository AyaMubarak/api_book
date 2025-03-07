﻿// <auto-generated />
using System;
using Book_Infrastructer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Book_Infrastructer.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Book_Core.Models.Cities", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Gov_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Gov_Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Book_Core.Models.Classifications", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classifications");
                });

            modelBuilder.Entity("Book_Core.Models.CustomerStores", b =>
                {
                    b.Property<int>("Cus_Id")
                        .HasColumnType("int");

                    b.Property<int>("Store_Id")
                        .HasColumnType("int");

                    b.HasKey("Cus_Id", "Store_Id");

                    b.HasIndex("Store_Id");

                    b.ToTable("CustomerStores");
                });

            modelBuilder.Entity("Book_Core.Models.Governments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Governments");
                });

            modelBuilder.Entity("Book_Core.Models.InvIteamStores", b =>
                {
                    b.Property<int>("Store_Id")
                        .HasColumnType("int");

                    b.Property<int>("Iteam_Id")
                        .HasColumnType("int");

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<int>("Factor")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<double>("ReversedQuintity")
                        .HasColumnType("float");

                    b.HasKey("Store_Id", "Iteam_Id");

                    b.HasIndex("Iteam_Id");

                    b.ToTable("InvIteamStores");
                });

            modelBuilder.Entity("Book_Core.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Cus_Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPosted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReviewed")
                        .HasColumnType("bit");

                    b.Property<double>("NetPrice")
                        .HasColumnType("float");

                    b.Property<int>("Payment_Type")
                        .HasColumnType("int");

                    b.Property<int>("Transaction_Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Cus_Id");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("Book_Core.Models.InvoiceDetails", b =>
                {
                    b.Property<int>("Invoice_Id")
                        .HasColumnType("int");

                    b.Property<int>("Iteam_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Factor")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("Unit_id")
                        .HasColumnType("int");

                    b.HasKey("Invoice_Id", "Iteam_Id");

                    b.HasIndex("Iteam_Id");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("Book_Core.Models.Iteams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MG_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Sub2_Id")
                        .HasColumnType("int");

                    b.Property<int>("Sub_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MG_Id");

                    b.HasIndex("Sub2_Id");

                    b.HasIndex("Sub_Id");

                    b.ToTable("Iteams");
                });

            modelBuilder.Entity("Book_Core.Models.IteamsUnites", b =>
                {
                    b.Property<int>("Unit_Id")
                        .HasColumnType("int");

                    b.Property<int>("Iteam_Id")
                        .HasColumnType("int");

                    b.Property<int>("Factor")
                        .HasColumnType("int");

                    b.HasKey("Unit_Id", "Iteam_Id");

                    b.HasIndex("Iteam_Id");

                    b.ToTable("IteamsUnites");
                });

            modelBuilder.Entity("Book_Core.Models.MainGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MainGroup");
                });

            modelBuilder.Entity("Book_Core.Models.ShoppingCartIteams", b =>
                {
                    b.Property<int>("Iteam_Id")
                        .HasColumnType("int");

                    b.Property<int>("Store_Id")
                        .HasColumnType("int");

                    b.Property<int>("Cus_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<int>("Unit_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Iteam_Id", "Store_Id", "Cus_Id");

                    b.HasIndex("Cus_Id");

                    b.HasIndex("Store_Id");

                    b.ToTable("ShoppingCartIteams");
                });

            modelBuilder.Entity("Book_Core.Models.Stores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("City_Id")
                        .HasColumnType("int");

                    b.Property<int>("Gov_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zone_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("City_Id");

                    b.HasIndex("Gov_Id");

                    b.HasIndex("Zone_Id");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Book_Core.Models.SubGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MG_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MG_Id");

                    b.ToTable("SubGroup");
                });

            modelBuilder.Entity("Book_Core.Models.SubGroup2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MG_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("sub_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MG_Id");

                    b.HasIndex("sub_Id");

                    b.ToTable("SubGroup2");
                });

            modelBuilder.Entity("Book_Core.Models.Units", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("Book_Core.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("City_Id")
                        .HasColumnType("int");

                    b.Property<int>("Class_Id")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("Gov_Id")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("Zone_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("City_Id");

                    b.HasIndex("Class_Id");

                    b.HasIndex("Gov_Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("Zone_Id");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Book_Core.Models.Zones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("City_Id")
                        .HasColumnType("int");

                    b.Property<int>("Gov_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("City_Id");

                    b.HasIndex("Gov_Id");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Book_Core.Models.Cities", b =>
                {
                    b.HasOne("Book_Core.Models.Governments", "Governments")
                        .WithMany("Cities")
                        .HasForeignKey("Gov_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Governments");
                });

            modelBuilder.Entity("Book_Core.Models.CustomerStores", b =>
                {
                    b.HasOne("Book_Core.Models.Users", "Users")
                        .WithMany("CustomerStores")
                        .HasForeignKey("Cus_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Stores", "Stores")
                        .WithMany("CustomerStores")
                        .HasForeignKey("Store_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stores");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Book_Core.Models.InvIteamStores", b =>
                {
                    b.HasOne("Book_Core.Models.Iteams", "Iteams")
                        .WithMany("InvIteamStores")
                        .HasForeignKey("Iteam_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Stores", "Stores")
                        .WithMany("InvIteamStores")
                        .HasForeignKey("Store_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Iteams");

                    b.Navigation("Stores");
                });

            modelBuilder.Entity("Book_Core.Models.Invoice", b =>
                {
                    b.HasOne("Book_Core.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("Cus_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Book_Core.Models.InvoiceDetails", b =>
                {
                    b.HasOne("Book_Core.Models.Invoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("Invoice_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Iteams", "Iteams")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("Iteam_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Iteams");
                });

            modelBuilder.Entity("Book_Core.Models.Iteams", b =>
                {
                    b.HasOne("Book_Core.Models.MainGroup", "MainGroup")
                        .WithMany("Iteams")
                        .HasForeignKey("MG_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.SubGroup2", "SubGroup2")
                        .WithMany("Iteams")
                        .HasForeignKey("Sub2_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.SubGroup", "SubGroup")
                        .WithMany("Iteams")
                        .HasForeignKey("Sub_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainGroup");

                    b.Navigation("SubGroup");

                    b.Navigation("SubGroup2");
                });

            modelBuilder.Entity("Book_Core.Models.IteamsUnites", b =>
                {
                    b.HasOne("Book_Core.Models.Iteams", "Iteams")
                        .WithMany("IteamsUnites")
                        .HasForeignKey("Iteam_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Units", "Units")
                        .WithMany("IteamsUnites")
                        .HasForeignKey("Unit_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Iteams");

                    b.Navigation("Units");
                });

            modelBuilder.Entity("Book_Core.Models.ShoppingCartIteams", b =>
                {
                    b.HasOne("Book_Core.Models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("Cus_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Iteams", "Iteams")
                        .WithMany()
                        .HasForeignKey("Iteam_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Stores", "Stores")
                        .WithMany()
                        .HasForeignKey("Store_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Iteams");

                    b.Navigation("Stores");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Book_Core.Models.Stores", b =>
                {
                    b.HasOne("Book_Core.Models.Cities", "Cities")
                        .WithMany("Stores")
                        .HasForeignKey("City_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Governments", "Governments")
                        .WithMany("Stores")
                        .HasForeignKey("Gov_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Zones", "Zones")
                        .WithMany("Stores")
                        .HasForeignKey("Zone_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cities");

                    b.Navigation("Governments");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("Book_Core.Models.SubGroup", b =>
                {
                    b.HasOne("Book_Core.Models.MainGroup", "MainGroup")
                        .WithMany("SubGroup")
                        .HasForeignKey("MG_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainGroup");
                });

            modelBuilder.Entity("Book_Core.Models.SubGroup2", b =>
                {
                    b.HasOne("Book_Core.Models.MainGroup", "MainGroup")
                        .WithMany("SubGroup2")
                        .HasForeignKey("MG_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.SubGroup", "SubGroup")
                        .WithMany("SubGroup2")
                        .HasForeignKey("sub_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainGroup");

                    b.Navigation("SubGroup");
                });

            modelBuilder.Entity("Book_Core.Models.Users", b =>
                {
                    b.HasOne("Book_Core.Models.Cities", "Cities")
                        .WithMany("Users")
                        .HasForeignKey("City_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Classifications", "Classifications")
                        .WithMany("Users")
                        .HasForeignKey("Class_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Governments", "Governments")
                        .WithMany("Users")
                        .HasForeignKey("Gov_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Zones", "Zones")
                        .WithMany("Users")
                        .HasForeignKey("Zone_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cities");

                    b.Navigation("Classifications");

                    b.Navigation("Governments");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("Book_Core.Models.Zones", b =>
                {
                    b.HasOne("Book_Core.Models.Cities", "Cities")
                        .WithMany("Zones")
                        .HasForeignKey("City_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Governments", "Governments")
                        .WithMany("Zones")
                        .HasForeignKey("Gov_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cities");

                    b.Navigation("Governments");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Book_Core.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Book_Core.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Book_Core.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Book_Core.Models.Users", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Book_Core.Models.Cities", b =>
                {
                    b.Navigation("Stores");

                    b.Navigation("Users");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("Book_Core.Models.Classifications", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Book_Core.Models.Governments", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Stores");

                    b.Navigation("Users");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("Book_Core.Models.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("Book_Core.Models.Iteams", b =>
                {
                    b.Navigation("InvIteamStores");

                    b.Navigation("InvoiceDetails");

                    b.Navigation("IteamsUnites");
                });

            modelBuilder.Entity("Book_Core.Models.MainGroup", b =>
                {
                    b.Navigation("Iteams");

                    b.Navigation("SubGroup");

                    b.Navigation("SubGroup2");
                });

            modelBuilder.Entity("Book_Core.Models.Stores", b =>
                {
                    b.Navigation("CustomerStores");

                    b.Navigation("InvIteamStores");
                });

            modelBuilder.Entity("Book_Core.Models.SubGroup", b =>
                {
                    b.Navigation("Iteams");

                    b.Navigation("SubGroup2");
                });

            modelBuilder.Entity("Book_Core.Models.SubGroup2", b =>
                {
                    b.Navigation("Iteams");
                });

            modelBuilder.Entity("Book_Core.Models.Units", b =>
                {
                    b.Navigation("IteamsUnites");
                });

            modelBuilder.Entity("Book_Core.Models.Users", b =>
                {
                    b.Navigation("CustomerStores");
                });

            modelBuilder.Entity("Book_Core.Models.Zones", b =>
                {
                    b.Navigation("Stores");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
