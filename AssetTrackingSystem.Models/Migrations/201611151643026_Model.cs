namespace AssetTrackingSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssetLocations", "ShortName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Branches", "ShortName", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Branches", "ShortName", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.AssetLocations", "ShortName", c => c.String(nullable: false, maxLength: 3));
        }
    }
}
