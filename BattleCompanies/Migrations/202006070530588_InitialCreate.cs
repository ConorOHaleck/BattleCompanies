namespace BattleCompanies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campaigns",
                c => new
                    {
                        CampaignID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CampaignID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Size = c.Int(nullable: false),
                        CompCampaign_CampaignID = c.Int(),
                        CompFaction_FactionID = c.Int(),
                        CompUser_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.CompanyID)
                .ForeignKey("dbo.Campaigns", t => t.CompCampaign_CampaignID)
                .ForeignKey("dbo.Factions", t => t.CompFaction_FactionID)
                .ForeignKey("dbo.Users", t => t.CompUser_UserID)
                .Index(t => t.CompCampaign_CampaignID)
                .Index(t => t.CompFaction_FactionID)
                .Index(t => t.CompUser_UserID);
            
            CreateTable(
                "dbo.Factions",
                c => new
                    {
                        FactionID = c.Int(nullable: false, identity: true),
                        FactionName = c.String(),
                    })
                .PrimaryKey(t => t.FactionID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.Soldiers",
                c => new
                    {
                        SoldierID = c.Int(nullable: false, identity: true),
                        SoldierName = c.String(),
                        PointCost = c.Short(nullable: false),
                        Movement = c.Byte(nullable: false),
                        Fight = c.Byte(nullable: false),
                        Shoot = c.Byte(nullable: false),
                        Strength = c.Byte(nullable: false),
                        Defense = c.Byte(nullable: false),
                        Attacks = c.Byte(nullable: false),
                        Wounds = c.Byte(nullable: false),
                        Courage = c.Byte(nullable: false),
                        Experience = c.Byte(nullable: false),
                        Might = c.Byte(),
                        Will = c.Byte(),
                        Fate = c.Byte(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Company_CompanyID = c.Int(),
                    })
                .PrimaryKey(t => t.SoldierID)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyID)
                .Index(t => t.Company_CompanyID);
            
            CreateTable(
                "dbo.Keywords",
                c => new
                    {
                        KeywordID = c.Int(nullable: false, identity: true),
                        KeywordText = c.String(),
                    })
                .PrimaryKey(t => t.KeywordID);
            
            CreateTable(
                "dbo.Wargears",
                c => new
                    {
                        WargearID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.WargearID);
            
            CreateTable(
                "dbo.UserCampaigns",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Campaign_CampaignID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Campaign_CampaignID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Campaigns", t => t.Campaign_CampaignID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Campaign_CampaignID);
            
            CreateTable(
                "dbo.SoldierKeywords",
                c => new
                    {
                        Soldier_SoldierID = c.Int(nullable: false),
                        Keyword_KeywordID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Soldier_SoldierID, t.Keyword_KeywordID })
                .ForeignKey("dbo.Soldiers", t => t.Soldier_SoldierID, cascadeDelete: true)
                .ForeignKey("dbo.Keywords", t => t.Keyword_KeywordID, cascadeDelete: true)
                .Index(t => t.Soldier_SoldierID)
                .Index(t => t.Keyword_KeywordID);
            
            CreateTable(
                "dbo.WargearSoldiers",
                c => new
                    {
                        Wargear_WargearID = c.Int(nullable: false),
                        Soldier_SoldierID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Wargear_WargearID, t.Soldier_SoldierID })
                .ForeignKey("dbo.Wargears", t => t.Wargear_WargearID, cascadeDelete: true)
                .ForeignKey("dbo.Soldiers", t => t.Soldier_SoldierID, cascadeDelete: true)
                .Index(t => t.Wargear_WargearID)
                .Index(t => t.Soldier_SoldierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WargearSoldiers", "Soldier_SoldierID", "dbo.Soldiers");
            DropForeignKey("dbo.WargearSoldiers", "Wargear_WargearID", "dbo.Wargears");
            DropForeignKey("dbo.SoldierKeywords", "Keyword_KeywordID", "dbo.Keywords");
            DropForeignKey("dbo.SoldierKeywords", "Soldier_SoldierID", "dbo.Soldiers");
            DropForeignKey("dbo.Soldiers", "Company_CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Companies", "CompUser_UserID", "dbo.Users");
            DropForeignKey("dbo.UserCampaigns", "Campaign_CampaignID", "dbo.Campaigns");
            DropForeignKey("dbo.UserCampaigns", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.Companies", "CompFaction_FactionID", "dbo.Factions");
            DropForeignKey("dbo.Companies", "CompCampaign_CampaignID", "dbo.Campaigns");
            DropIndex("dbo.WargearSoldiers", new[] { "Soldier_SoldierID" });
            DropIndex("dbo.WargearSoldiers", new[] { "Wargear_WargearID" });
            DropIndex("dbo.SoldierKeywords", new[] { "Keyword_KeywordID" });
            DropIndex("dbo.SoldierKeywords", new[] { "Soldier_SoldierID" });
            DropIndex("dbo.UserCampaigns", new[] { "Campaign_CampaignID" });
            DropIndex("dbo.UserCampaigns", new[] { "User_UserID" });
            DropIndex("dbo.Soldiers", new[] { "Company_CompanyID" });
            DropIndex("dbo.Companies", new[] { "CompUser_UserID" });
            DropIndex("dbo.Companies", new[] { "CompFaction_FactionID" });
            DropIndex("dbo.Companies", new[] { "CompCampaign_CampaignID" });
            DropTable("dbo.WargearSoldiers");
            DropTable("dbo.SoldierKeywords");
            DropTable("dbo.UserCampaigns");
            DropTable("dbo.Wargears");
            DropTable("dbo.Keywords");
            DropTable("dbo.Soldiers");
            DropTable("dbo.Users");
            DropTable("dbo.Factions");
            DropTable("dbo.Companies");
            DropTable("dbo.Campaigns");
        }
    }
}
