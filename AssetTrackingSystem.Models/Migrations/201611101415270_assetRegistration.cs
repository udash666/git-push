namespace AssetTrackingSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assetRegistration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetRegistrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssetId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        RegistrationBy = c.String(),
                        Serial = c.String(),
                        AssetEntry_Id = c.Int(),
                        AssetLocation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssetEntries", t => t.AssetEntry_Id)
                .ForeignKey("dbo.AssetLocations", t => t.AssetLocation_Id)
                .Index(t => t.AssetEntry_Id)
                .Index(t => t.AssetLocation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetRegistrations", "AssetLocation_Id", "dbo.AssetLocations");
            DropForeignKey("dbo.AssetRegistrations", "AssetEntry_Id", "dbo.AssetEntries");
            DropIndex("dbo.AssetRegistrations", new[] { "AssetLocation_Id" });
            DropIndex("dbo.AssetRegistrations", new[] { "AssetEntry_Id" });
            DropTable("dbo.AssetRegistrations");
        }
    }
}
