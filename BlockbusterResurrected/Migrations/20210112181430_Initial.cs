using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlockbusterResurrected.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GameTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "GConsoles",
                columns: table => new
                {
                    GConsoleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GConsoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GConsoles", x => x.GConsoleId);
                });

            migrationBuilder.CreateTable(
                name: "ConsoleGame",
                columns: table => new
                {
                    ConsoleGameId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GConsoleId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsoleGame", x => x.ConsoleGameId);
                    table.ForeignKey(
                        name: "FK_ConsoleGame_GConsoles_GConsoleId",
                        column: x => x.GConsoleId,
                        principalTable: "GConsoles",
                        principalColumn: "GConsoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConsoleGame_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsoleGame_GConsoleId",
                table: "ConsoleGame",
                column: "GConsoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsoleGame_GameId",
                table: "ConsoleGame",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsoleGame");

            migrationBuilder.DropTable(
                name: "GConsoles");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
