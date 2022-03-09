using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tchaps.Impotquebec.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ssn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddressApartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressStreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressMunicipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormDataTypes",
                columns: table => new
                {
                    FormDataTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormDataTypes", x => x.FormDataTypeId);
                });

            migrationBuilder.CreateTable(
                name: "TaxForms",
                columns: table => new
                {
                    TaxFormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxForms", x => x.TaxFormId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Declarations",
                columns: table => new
                {
                    DeclarationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FiscalYear = table.Column<short>(type: "smallint", nullable: false),
                    TotalIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalDeductions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxableIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NonRefundableTaxCredits = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IncomeTaxAndContributions = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Refund = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BalanceDue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxFormId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declarations", x => x.DeclarationId);
                    table.ForeignKey(
                        name: "FK_Declarations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Declarations_TaxForms_TaxFormId",
                        column: x => x.TaxFormId,
                        principalTable: "TaxForms",
                        principalColumn: "TaxFormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxFormSections",
                columns: table => new
                {
                    TaxFormSectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxFormId = table.Column<int>(type: "int", nullable: false),
                    InternalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineNumbers = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxFormSections", x => x.TaxFormSectionId);
                    table.ForeignKey(
                        name: "FK_TaxFormSections_TaxForms_TaxFormId",
                        column: x => x.TaxFormId,
                        principalTable: "TaxForms",
                        principalColumn: "TaxFormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationDetails",
                columns: table => new
                {
                    DeclarationDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeclarationId = table.Column<int>(type: "int", nullable: false),
                    TaxFormLineId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<float>(type: "real", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationDetails", x => x.DeclarationDetailId);
                    table.ForeignKey(
                        name: "FK_DeclarationDetails_Declarations_DeclarationId",
                        column: x => x.DeclarationId,
                        principalTable: "Declarations",
                        principalColumn: "DeclarationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxFormLines",
                columns: table => new
                {
                    TaxFormLineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxFormId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<short>(type: "smallint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    TaxFormSectionId = table.Column<int>(type: "int", nullable: true),
                    FormDataTypeId = table.Column<int>(type: "int", nullable: true),
                    ItemLists = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxFormLines", x => x.TaxFormLineId);
                    table.ForeignKey(
                        name: "FK_TaxFormLines_FormDataTypes_FormDataTypeId",
                        column: x => x.FormDataTypeId,
                        principalTable: "FormDataTypes",
                        principalColumn: "FormDataTypeId");
                    table.ForeignKey(
                        name: "FK_TaxFormLines_TaxForms_TaxFormId",
                        column: x => x.TaxFormId,
                        principalTable: "TaxForms",
                        principalColumn: "TaxFormId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxFormLines_TaxFormSections_TaxFormSectionId",
                        column: x => x.TaxFormSectionId,
                        principalTable: "TaxFormSections",
                        principalColumn: "TaxFormSectionId");
                });

            migrationBuilder.InsertData(
                table: "TaxForms",
                columns: new[] { "TaxFormId", "Code", "Description", "Name" },
                values: new object[] { 1, "TP-1.D-V", "", "INCOME TAX RETURN" });

            migrationBuilder.InsertData(
                table: "TaxFormSections",
                columns: new[] { "TaxFormSectionId", "Description", "InternalName", "LineNumbers", "Name", "Rank", "TaxFormId" },
                values: new object[,]
                {
                    { 1, "Add lines 101 and 105 through 164. ", "TotalIncome", "[101,105-164]", "Total income", 0, 1 },
                    { 2, "Add lines 201 through 207, 214 through 231, and 234 through 252. ", "TotalDeductions", "[201-207,214-231,234-252]", "Net income", 0, 1 },
                    { 3, "Add lines 287 through 297", "TotalDeductions", "[287-297]", "Taxable income", 0, 1 },
                    { 4, "", "TotalIncome", "", "Non-refundable tax credits", 0, 1 },
                    { 5, "", "IncomeTaxAndContributions", "", "Income tax and contributions", 0, 1 },
                    { 6, "", "RefundOrBalanceDue", "", "Refund or balance due", 0, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationDetails_DeclarationId",
                table: "DeclarationDetails",
                column: "DeclarationId");

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_TaxFormId",
                table: "Declarations",
                column: "TaxFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_UserId",
                table: "Declarations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxFormLines_FormDataTypeId",
                table: "TaxFormLines",
                column: "FormDataTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxFormLines_TaxFormId",
                table: "TaxFormLines",
                column: "TaxFormId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxFormLines_TaxFormSectionId",
                table: "TaxFormLines",
                column: "TaxFormSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxFormSections_TaxFormId",
                table: "TaxFormSections",
                column: "TaxFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DeclarationDetails");

            migrationBuilder.DropTable(
                name: "TaxFormLines");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Declarations");

            migrationBuilder.DropTable(
                name: "FormDataTypes");

            migrationBuilder.DropTable(
                name: "TaxFormSections");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TaxForms");
        }
    }
}
