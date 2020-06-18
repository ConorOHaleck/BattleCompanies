using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleCompanies.Migrations
{
    public partial class SixSeventeen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Influence",
                table: "Companies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Influence",
                table: "Companies");
        }
    }
}
