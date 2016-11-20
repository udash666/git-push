namespace AssetTrackingSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssetPurchaseEntry : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssetEntries", "WarrentyPeriod", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssetEntries", "WarrentyPeriod", c => c.DateTime(nullable: false));
        }
    }
}
