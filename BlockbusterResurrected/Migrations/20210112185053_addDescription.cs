using Microsoft.EntityFrameworkCore.Migrations;

namespace BlockbusterResurrected.Migrations
{
    public partial class addDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "GConsoles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "GConsoles");
        }
    }
}
