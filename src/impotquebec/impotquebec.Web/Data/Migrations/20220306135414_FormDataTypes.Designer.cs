﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tchaps.Impotquebec.Data;

#nullable disable

namespace Tchaps.Impotquebec.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220306135414_FormDataTypes")]
    partial class FormDataTypes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tchaps.Impotquebec.Models.Declaration", b =>
                {
                    b.Property<int>("DeclarationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeclarationId"), 1L, 1);

                    b.Property<decimal>("BalanceDue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<short>("FiscalYear")
                        .HasColumnType("smallint");

                    b.Property<string>("History")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("IncomeTaxAndContributions")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NetIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("NonRefundableTaxCredits")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Refund")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TaxFormId")
                        .HasColumnType("int");

                    b.Property<decimal>("TaxableIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalDeductions")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalIncome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("DeclarationId");

                    b.HasIndex("TaxFormId");

                    b.HasIndex("UserId");

                    b.ToTable("Declarations");
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.DeclarationDetail", b =>
                {
                    b.Property<float>("DeclarationDetailId")
                        .HasColumnType("real");

                    b.Property<int>("DeclarationId")
                        .HasColumnType("int");

                    b.Property<float>("LineNumber")
                        .HasColumnType("real");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeclarationDetailId");

                    b.HasIndex("DeclarationId");

                    b.ToTable("DeclarationDetails");
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.FormDataType", b =>
                {
                    b.Property<int>("FormDataTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FormDataTypeId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormDataTypeId");

                    b.ToTable("FormDataTypes");
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.IdentityProfile", b =>
                {
                    b.Property<int>("IdentityProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdentityProfileId"), 1L, 1);

                    b.Property<string>("AddressApartment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressMunicipality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressPostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressProvince")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressStreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressStreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Ssn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IdentityProfileId");

                    b.HasIndex("UserId");

                    b.ToTable("IdentityProfiles");
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.TaxForm", b =>
                {
                    b.Property<int>("TaxFormId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaxFormId"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaxFormId");

                    b.ToTable("TaxForms");

                    b.HasData(
                        new
                        {
                            TaxFormId = 1,
                            Code = "TP-1.D-V",
                            Description = "",
                            Name = "INCOME TAX RETURN"
                        });
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.TaxFormLine", b =>
                {
                    b.Property<int>("TaxFormLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaxFormLineId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReadOnly")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<string>("LineNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("Rank")
                        .HasColumnType("smallint");

                    b.Property<int>("TaxFormId")
                        .HasColumnType("int");

                    b.Property<int?>("TaxFormSectionId")
                        .HasColumnType("int");

                    b.HasKey("TaxFormLineId");

                    b.HasIndex("TaxFormId");

                    b.HasIndex("TaxFormSectionId");

                    b.ToTable("TaxFormLines");
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.TaxFormSection", b =>
                {
                    b.Property<int>("TaxFormSectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaxFormSectionId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LineNumbers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<int>("TaxFormId")
                        .HasColumnType("int");

                    b.HasKey("TaxFormSectionId");

                    b.HasIndex("TaxFormId");

                    b.ToTable("TaxFormSections");

                    b.HasData(
                        new
                        {
                            TaxFormSectionId = 1,
                            Description = "Add lines 101 and 105 through 164. ",
                            InternalName = "TotalIncome",
                            LineNumbers = "[101,105-164]",
                            Name = "Total income",
                            Rank = 0,
                            TaxFormId = 1
                        },
                        new
                        {
                            TaxFormSectionId = 2,
                            Description = "Add lines 201 through 207, 214 through 231, and 234 through 252. ",
                            InternalName = "TotalDeductions",
                            LineNumbers = "[201-207,214-231,234-252]",
                            Name = "Net income",
                            Rank = 0,
                            TaxFormId = 1
                        },
                        new
                        {
                            TaxFormSectionId = 3,
                            Description = "Add lines 287 through 297",
                            InternalName = "TotalDeductions",
                            LineNumbers = "[287-297]",
                            Name = "Taxable income",
                            Rank = 0,
                            TaxFormId = 1
                        },
                        new
                        {
                            TaxFormSectionId = 4,
                            Description = "",
                            InternalName = "TotalIncome",
                            LineNumbers = "",
                            Name = "Non-refundable tax credits",
                            Rank = 0,
                            TaxFormId = 1
                        },
                        new
                        {
                            TaxFormSectionId = 5,
                            Description = "",
                            InternalName = "IncomeTaxAndContributions",
                            LineNumbers = "",
                            Name = "Income tax and contributions",
                            Rank = 0,
                            TaxFormId = 1
                        },
                        new
                        {
                            TaxFormSectionId = 6,
                            Description = "",
                            InternalName = "RefundOrBalanceDue",
                            LineNumbers = "",
                            Name = "Refund or balance due",
                            Rank = 0,
                            TaxFormId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.Declaration", b =>
                {
                    b.HasOne("Tchaps.Impotquebec.Models.TaxForm", "TaxForm")
                        .WithMany()
                        .HasForeignKey("TaxFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaxForm");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.DeclarationDetail", b =>
                {
                    b.HasOne("Tchaps.Impotquebec.Models.Declaration", null)
                        .WithMany("Details")
                        .HasForeignKey("DeclarationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.IdentityProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.TaxFormLine", b =>
                {
                    b.HasOne("Tchaps.Impotquebec.Models.TaxForm", "TaxForm")
                        .WithMany("TaxFormLines")
                        .HasForeignKey("TaxFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tchaps.Impotquebec.Models.TaxFormSection", "TaxFormSection")
                        .WithMany()
                        .HasForeignKey("TaxFormSectionId");

                    b.Navigation("TaxForm");

                    b.Navigation("TaxFormSection");
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.TaxFormSection", b =>
                {
                    b.HasOne("Tchaps.Impotquebec.Models.TaxForm", "TaxForm")
                        .WithMany("TaxFormSections")
                        .HasForeignKey("TaxFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaxForm");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.Declaration", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("Tchaps.Impotquebec.Models.TaxForm", b =>
                {
                    b.Navigation("TaxFormLines");

                    b.Navigation("TaxFormSections");
                });
#pragma warning restore 612, 618
        }
    }
}
