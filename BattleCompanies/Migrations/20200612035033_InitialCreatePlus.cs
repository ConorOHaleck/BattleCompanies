using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleCompanies.Migrations
{
    public partial class InitialCreatePlus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CampaignName",
                table: "Campaigns",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CampaignName",
                table: "Campaigns");
        }
    }
}
