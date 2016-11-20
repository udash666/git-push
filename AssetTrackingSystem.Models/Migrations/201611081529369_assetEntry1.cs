namespace AssetTrackingSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assetEntry1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssetEntries", "GeneralCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.AssetEntries", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.AssetEntries", "SubCategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AssetEntries", "SubCategoryId");
            DropColumn("dbo.AssetEntries", "CategoryId");
            DropColumn("dbo.AssetEntries", "GeneralCategoryId");
        }
    }
}
