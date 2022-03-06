using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace impotquebec.Web.Data.Migrations
{
    public partial class TaxFormLine_IsRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                table: "TaxFormLines",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRequired",
                table: "TaxFormLines");
        }
    }
}
