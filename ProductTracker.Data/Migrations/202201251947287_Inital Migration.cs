namespace ProductTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        MSRP = c.Int(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                        Purchase_PurchaseId = c.Int(),
                        Resell_ResellId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Purchase", t => t.Purchase_PurchaseId)
                .ForeignKey("dbo.Resell", t => t.Resell_ResellId)
                .Index(t => t.Purchase_PurchaseId)
                .Index(t => t.Resell_ResellId);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ItemName = c.String(nullable: false),
                        PurchasePrice = c.Int(nullable: false),
                        StoreBoughtFrom = c.String(nullable: false),
                        Condition = c.String(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Resell",
                c => new
                    {
                        ResellId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SalePrice = c.Int(nullable: false),
                        Customer = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        ResellDate = c.DateTime(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ResellId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.Product_ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.Product_ProductId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Resell", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "Resell_ResellId", "dbo.Resell");
            DropForeignKey("dbo.Resell", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Purchase", "Product_ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "Purchase_PurchaseId", "dbo.Purchase");
            DropForeignKey("dbo.Purchase", "ProductId", "dbo.Product");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Resell", new[] { "Product_ProductId" });
            DropIndex("dbo.Resell", new[] { "ProductId" });
            DropIndex("dbo.Purchase", new[] { "Product_ProductId" });
            DropIndex("dbo.Purchase", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "Resell_ResellId" });
            DropIndex("dbo.Product", new[] { "Purchase_PurchaseId" });
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
