namespace AssetTrackingSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asset : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssetEntries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        Vendor = c.String(),
                        DetailsCategoryId = c.Int(nullable: false),
                        WarrentyPeriod = c.DateTime(nullable: false),
                        Price = c.String(),
                        Quantity = c.Int(nullable: false),
                        Serial = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DetailsCategories", t => t.DetailsCategoryId, cascadeDelete: true)
                .Index(t => t.DetailsCategoryId);
            
            AlterColumn("dbo.Categories", "Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.SubCategories", "Code", c => c.String(nullable: false, maxLength: 3));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetEntries", "DetailsCategoryId", "dbo.DetailsCategories");
            DropIndex("dbo.AssetEntries", new[] { "DetailsCategoryId" });
            AlterColumn("dbo.SubCategories", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Code", c => c.String(nullable: false));
            DropTable("dbo.AssetEntries");
        }
    }
}
