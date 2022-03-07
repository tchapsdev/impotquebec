using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tchaps.Impotquebec.Data.Migrations
{
    public partial class TaxFormLine_readOnly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "TaxFormLines",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "TaxFormLines");
        }
    }
}
