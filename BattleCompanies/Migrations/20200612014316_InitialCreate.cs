using Microsoft.EntityFrameworkCore.Migrations;

namespace BattleCompanies.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    FactionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.FactionID);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    KeywordID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeywordText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.KeywordID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Wargears",
                columns: table => new
                {
                    WargearID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wargears", x => x.WargearID);
                });

            migrationBuilder.CreateTable(
                name: "BaseClasses",
                columns: table => new
                {
                    BaseClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true),
                    AssociatedFactionFactionID = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignID);
                    table.ForeignKey(
                        name: "FK_Campaigns_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FactionWargear",
                columns: table => new
                {
                    FactionID = table.Column<int>(nullable: false),
                    WargearID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactionWargear", x => new { x.FactionID, x.WargearID });
                    table.ForeignKey(
                        name: "FK_FactionWargear_Factions_FactionID",
                        column: x => x.FactionID,
                        principalTable: "Factions",
                        principalColumn: "FactionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FactionWargear_Wargears_WargearID",
                        column: x => x.WargearID,
                        principalTable: "Wargears",
                        principalColumn: "WargearID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    CompUserUserID = table.Column<int>(nullable: true),
                    CompCampaignCampaignID = table.Column<int>(nullable: true),
                    CompFactionFactionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Companies_Campaigns_CompCampaignCampaignID",
                        column: x => x.CompCampaignCampaignID,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Factions_CompFactionFactionID",
                        column: x => x.CompFactionFactionID,
                        principalTable: "Factions",
                        principalColumn: "FactionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Users_CompUserUserID",
                        column: x => x.CompUserUserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Soldiers",
                columns: table => new
                {
                    SoldierID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoldierName = table.Column<string>(nullable: true),
                    PointCost = table.Column<short>(nullable: false),
                    Movement = table.Column<byte>(nullable: false),
                    Fight = table.Column<byte>(nullable: false),
                    Shoot = table.Column<byte>(nullable: false),
                    Strength = table.Column<byte>(nullable: false),
                    Defense = table.Column<byte>(nullable: false),
                    Attacks = table.Column<byte>(nullable: false),
                    Wounds = table.Column<byte>(nullable: false),
                    Courage = table.Column<byte>(nullable: false),
                    Might = table.Column<byte>(nullable: false),
                    Will = table.Column<byte>(nullable: false),
                    Fate = table.Column<byte>(nullable: false),
                    Experience = table.Column<byte>(nullable: false),
                    CompanyID = table.Column<int>(nullable: true),
                    SoldierClassBaseClassID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soldiers", x => x.SoldierID);
                    table.ForeignKey(
                        name: "FK_Soldiers_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Soldiers_BaseClasses_SoldierClassBaseClassID",
                        column: x => x.SoldierClassBaseClassID,
                        principalTable: "BaseClasses",
                        principalColumn: "BaseClassID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoldierKeywords",
                columns: table => new
                {
                    SoldierID = table.Column<int>(nullable: false),
                    KeywordID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldierKeywords", x => new { x.KeywordID, x.SoldierID });
                    table.ForeignKey(
                        name: "FK_SoldierKeywords_Keywords_KeywordID",
                        column: x => x.KeywordID,
                        principalTable: "Keywords",
                        principalColumn: "KeywordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoldierKeywords_Soldiers_SoldierID",
                        column: x => x.SoldierID,
                        principalTable: "Soldiers",
                        principalColumn: "SoldierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoldierWargear",
                columns: table => new
                {
                    SoldierID = table.Column<int>(nullable: false),
                    WargearID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldierWargear", x => new { x.WargearID, x.SoldierID });
                    table.ForeignKey(
                        name: "FK_SoldierWargear_Soldiers_SoldierID",
                        column: x => x.SoldierID,
                        principalTable: "Soldiers",
                        principalColumn: "SoldierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoldierWargear_Wargears_WargearID",
                        column: x => x.WargearID,
                        principalTable: "Wargears",
                        principalColumn: "WargearID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseClasses_AssociatedFactionFactionID",
                table: "BaseClasses",
                column: "AssociatedFactionFactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_UserID",
                table: "Campaigns",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompCampaignCampaignID",
                table: "Companies",
                column: "CompCampaignCampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompFactionFactionID",
                table: "Companies",
                column: "CompFactionFactionID");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CompUserUserID",
                table: "Companies",
                column: "CompUserUserID");

            migrationBuilder.CreateIndex(
                name: "IX_FactionWargear_WargearID",
                table: "FactionWargear",
                column: "WargearID");

            migrationBuilder.CreateIndex(
                name: "IX_SoldierKeywords_SoldierID",
                table: "SoldierKeywords",
                column: "SoldierID");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_CompanyID",
                table: "Soldiers",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_SoldierClassBaseClassID",
                table: "Soldiers",
                column: "SoldierClassBaseClassID");

            migrationBuilder.CreateIndex(
                name: "IX_SoldierWargear_SoldierID",
                table: "SoldierWargear",
                column: "SoldierID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactionWargear");

            migrationBuilder.DropTable(
                name: "SoldierKeywords");

            migrationBuilder.DropTable(
                name: "SoldierWargear");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "Soldiers");

            migrationBuilder.DropTable(
                name: "Wargears");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "BaseClasses");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
