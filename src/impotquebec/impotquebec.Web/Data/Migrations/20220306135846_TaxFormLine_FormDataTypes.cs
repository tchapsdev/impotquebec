using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace impotquebec.Web.Data.Migrations
{
    public partial class TaxFormLine_FormDataTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormDataTypeId",
                table: "TaxFormLines",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemLists",
                table: "TaxFormLines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxFormLines_FormDataTypeId",
                table: "TaxFormLines",
                column: "FormDataTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxFormLines_FormDataTypes_FormDataTypeId",
                table: "TaxFormLines",
                column: "FormDataTypeId",
                principalTable: "FormDataTypes",
                principalColumn: "FormDataTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaxFormLines_FormDataTypes_FormDataTypeId",
                table: "TaxFormLines");

            migrationBuilder.DropIndex(
                name: "IX_TaxFormLines_FormDataTypeId",
                table: "TaxFormLines");

            migrationBuilder.DropColumn(
                name: "FormDataTypeId",
                table: "TaxFormLines");

            migrationBuilder.DropColumn(
                name: "ItemLists",
                table: "TaxFormLines");
        }
    }
}
