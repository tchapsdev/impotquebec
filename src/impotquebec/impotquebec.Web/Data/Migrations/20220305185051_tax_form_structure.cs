using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tchaps.Impotquebec.Data.Migrations
{
    public partial class tax_form_structure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ssn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressApartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressStreetNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressStreetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressMunicipality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressProvince = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    DeclarationDetailId = table.Column<float>(type: "real", nullable: false),
                    DeclarationId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<float>(type: "real", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    TaxFormSectionId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxFormLines", x => x.TaxFormLineId);
                    table.ForeignKey(
                        name: "FK_TaxFormLines_TaxFormSections_TaxFormSectionId",
                        column: x => x.TaxFormSectionId,
                        principalTable: "TaxFormSections",
                        principalColumn: "TaxFormSectionId");
                    table.ForeignKey(
                        name: "FK_TaxFormLines_TaxForms_TaxFormId",
                        column: x => x.TaxFormId,
                        principalTable: "TaxForms",
                        principalColumn: "TaxFormId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TaxForms",
                columns: new[] { "TaxFormId", "Code", "Description", "Name" },
                values: new object[] { 1, "TP-1.D-V", "", "INCOME TAX RETURN" });

            migrationBuilder.InsertData(
                table: "TaxFormSections",
                columns: new[] { "TaxFormSectionId", "Description", "InternalName", "LineNumbers", "Name", "TaxFormId" },
                values: new object[,]
                {
                    { 1, "Add lines 101 and 105 through 164. ", "TotalIncome", "[101,105-164]", "Total income", 1 },
                    { 2, "Add lines 201 through 207, 214 through 231, and 234 through 252. ", "TotalDeductions", "[201-207,214-231,234-252]", "Net income", 1 },
                    { 3, "Add lines 287 through 297", "TotalDeductions", "[287-297]", "Taxable income", 1 },
                    { 4, "", "TotalIncome", "", "Non-refundable tax credits", 1 },
                    { 5, "", "IncomeTaxAndContributions", "", "Income tax and contributions", 1 },
                    { 6, "", "RefundOrBalanceDue", "", "Refund or balance due", 1 }
                });

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
                name: "IX_TaxFormSections_TaxFormId",
                table: "TaxFormSections",
                column: "TaxFormId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserId",
                table: "Profiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxFormLines_TaxFormSectionId",
                table: "TaxFormLines",
                column: "TaxFormSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxFormLines_TaxFormId",
                table: "TaxFormLines",
                column: "TaxFormId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeclarationDetails");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "TaxFormLines");

            migrationBuilder.DropTable(
                name: "Declarations");

            migrationBuilder.DropTable(
                name: "TaxFormSections");

            migrationBuilder.DropTable(
                name: "TaxForms");
        }
    }
}
