using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductivityAppV2.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DOW = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DayId",
                table: "Tasks",
                column: "DayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Days_DayId",
                table: "Tasks",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "DayId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Days_DayId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_DayId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "Tasks");
        }
    }
}
