namespace AssetTrackingSystem.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssetReg1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssetRegistrations", "RegistrationBy", c => c.String(nullable: false));
            AlterColumn("dbo.AssetRegistrations", "Serial", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssetRegistrations", "Serial", c => c.String());
            AlterColumn("dbo.AssetRegistrations", "RegistrationBy", c => c.String());
        }
    }
}
