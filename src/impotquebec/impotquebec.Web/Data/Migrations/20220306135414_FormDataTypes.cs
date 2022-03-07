using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tchaps.Impotquebec.Data.Migrations
{
    public partial class FormDataTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormDataTypes");
        }
    }
}
