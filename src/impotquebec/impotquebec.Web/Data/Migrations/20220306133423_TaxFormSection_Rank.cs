using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace impotquebec.Web.Data.Migrations
{
    public partial class TaxFormSection_Rank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "TaxFormSections",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "TaxFormSections");
        }
    }
}
