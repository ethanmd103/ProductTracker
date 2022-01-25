namespace ProductTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase", "ItemName", c => c.String(nullable: false));
            DropColumn("dbo.Purchase", "PurchaseName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchase", "PurchaseName", c => c.String(nullable: false));
            DropColumn("dbo.Purchase", "ItemName");
        }
    }
}
