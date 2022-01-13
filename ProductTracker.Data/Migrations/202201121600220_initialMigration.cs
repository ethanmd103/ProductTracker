namespace ProductTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        MSRP = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        PriceBoughtFor = c.Int(nullable: false),
                        StoreBoughtFrom = c.String(nullable: false),
                        Condition = c.String(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId);
            
            CreateTable(
                "dbo.Resell",
                c => new
                    {
                        ResellId = c.Int(nullable: false, identity: true),
                        SalePrice = c.Int(nullable: false),
                        Customer = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        ResellDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ResellId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PurchaseProduct",
                c => new
                    {
                        Purchase_PurchaseId = c.Int(nullable: false),
                        Product_ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Purchase_PurchaseId, t.Product_ProductID })
                .ForeignKey("dbo.Purchase", t => t.Purchase_PurchaseId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_ProductID, cascadeDelete: true)
                .Index(t => t.Purchase_PurchaseId)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.ResellProduct",
                c => new
                    {
                        Resell_ResellId = c.Int(nullable: false),
                        Product_ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Resell_ResellId, t.Product_ProductID })
                .ForeignKey("dbo.Resell", t => t.Resell_ResellId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_ProductID, cascadeDelete: true)
                .Index(t => t.Resell_ResellId)
                .Index(t => t.Product_ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ResellProduct", "Product_ProductID", "dbo.Product");
            DropForeignKey("dbo.ResellProduct", "Resell_ResellId", "dbo.Resell");
            DropForeignKey("dbo.PurchaseProduct", "Product_ProductID", "dbo.Product");
            DropForeignKey("dbo.PurchaseProduct", "Purchase_PurchaseId", "dbo.Purchase");
            DropIndex("dbo.ResellProduct", new[] { "Product_ProductID" });
            DropIndex("dbo.ResellProduct", new[] { "Resell_ResellId" });
            DropIndex("dbo.PurchaseProduct", new[] { "Product_ProductID" });
            DropIndex("dbo.PurchaseProduct", new[] { "Purchase_PurchaseId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.ResellProduct");
            DropTable("dbo.PurchaseProduct");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Resell");
            DropTable("dbo.Purchase");
            DropTable("dbo.Product");
        }
    }
}
