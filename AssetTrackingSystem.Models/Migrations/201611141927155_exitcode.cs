namespace AssetTrackingSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exitcode : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DetailsCategories", "Code", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.SubCategories", "Code", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Categories", "Code", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Branches", "ShortName", c => c.String(nullable: false, maxLength: 450));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Branches", "ShortName", c => c.String(maxLength: 450));
            AlterColumn("dbo.Categories", "Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.SubCategories", "Code", c => c.String(nullable: false, maxLength: 3));
            AlterColumn("dbo.DetailsCategories", "Code", c => c.String(nullable: false, maxLength: 3));
        }
    }
}
