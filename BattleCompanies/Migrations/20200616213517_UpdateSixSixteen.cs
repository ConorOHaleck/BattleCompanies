using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleCompanies.Migrations
{
    public partial class UpdateSixSixteen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_BaseClasses_SoldierClassBaseClassID",
                table: "Soldiers");

            migrationBuilder.DropTable(
                name: "BaseClasses");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_SoldierClassBaseClassID",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "SoldierClassBaseClassID",
                table: "Soldiers");

            migrationBuilder.AddColumn<bool>(
                name: "Bow",
                table: "Wargears",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwoHanded",
                table: "Wargears",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "WargearName",
                table: "Wargears",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bow",
                table: "Wargears");

            migrationBuilder.DropColumn(
                name: "TwoHanded",
                table: "Wargears");

            migrationBuilder.DropColumn(
                name: "WargearName",
                table: "Wargears");

            migrationBuilder.AddColumn<int>(
                name: "SoldierClassBaseClassID",
                table: "Soldiers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BaseClasses",
                columns: table => new
                {
                    BaseClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssociatedFactionFactionID = table.Column<int>(type: "int", nullable: true),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseClasses", x => x.BaseClassID);
                    table.ForeignKey(
                        name: "FK_BaseClasses_Factions_AssociatedFactionFactionID",
                        column: x => x.AssociatedFactionFactionID,
                        principalTable: "Factions",
                        principalColumn: "FactionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_SoldierClassBaseClassID",
                table: "Soldiers",
                column: "SoldierClassBaseClassID");

            migrationBuilder.CreateIndex(
                name: "IX_BaseClasses_AssociatedFactionFactionID",
                table: "BaseClasses",
                column: "AssociatedFactionFactionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_BaseClasses_SoldierClassBaseClassID",
                table: "Soldiers",
                column: "SoldierClassBaseClassID",
                principalTable: "BaseClasses",
                principalColumn: "BaseClassID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
