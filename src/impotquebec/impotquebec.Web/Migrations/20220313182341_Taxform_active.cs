using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tchaps.Impotquebec.Migrations
{
    public partial class Taxform_active : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TaxForms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "TaxForms");
        }
    }
}
