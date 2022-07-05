namespace Eticaret.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Main.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        MasterCategoryId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Main.MasterCategories", t => t.MasterCategoryId)
                .Index(t => t.MasterCategoryId);
            
            CreateTable(
                "Main.MasterCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Main.Products",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 100),
                        Image = c.String(nullable: false, maxLength: 500),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        Description = c.String(maxLength: 500),
                        UnitType = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Main.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "Main.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderNumber = c.String(maxLength: 20),
                        OrderTotal = c.Decimal(nullable: false, storeType: "money"),
                        CustomerId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Main.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "Main.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 100),
                        Surname = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 500),
                        City = c.String(nullable: false, maxLength: 100),
                        Country = c.String(nullable: false, maxLength: 100),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Management.Modules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Management.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Management.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 64, fixedLength: true),
                        FullName = c.String(maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Int.OrderProducts",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("Main.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("Main.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "Int.RoleModules",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.ModuleId })
                .ForeignKey("Management.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Management.Modules", t => t.ModuleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.ModuleId);
            
            CreateTable(
                "Int.UserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("Management.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("Management.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Int.UserRoles", "UserId", "Management.Users");
            DropForeignKey("Int.UserRoles", "RoleId", "Management.Roles");
            DropForeignKey("Int.RoleModules", "ModuleId", "Management.Modules");
            DropForeignKey("Int.RoleModules", "RoleId", "Management.Roles");
            DropForeignKey("Main.Products", "CategoryId", "Main.Categories");
            DropForeignKey("Int.OrderProducts", "ProductId", "Main.Products");
            DropForeignKey("Int.OrderProducts", "OrderId", "Main.Orders");
            DropForeignKey("Main.Orders", "CustomerId", "Main.Customers");
            DropForeignKey("Main.Categories", "MasterCategoryId", "Main.MasterCategories");
            DropIndex("Int.UserRoles", new[] { "UserId" });
            DropIndex("Int.UserRoles", new[] { "RoleId" });
            DropIndex("Int.RoleModules", new[] { "ModuleId" });
            DropIndex("Int.RoleModules", new[] { "RoleId" });
            DropIndex("Int.OrderProducts", new[] { "ProductId" });
            DropIndex("Int.OrderProducts", new[] { "OrderId" });
            DropIndex("Main.Orders", new[] { "CustomerId" });
            DropIndex("Main.Products", new[] { "CategoryId" });
            DropIndex("Main.Categories", new[] { "MasterCategoryId" });
            DropTable("Int.UserRoles");
            DropTable("Int.RoleModules");
            DropTable("Int.OrderProducts");
            DropTable("Management.Users");
            DropTable("Management.Roles");
            DropTable("Management.Modules");
            DropTable("Main.Customers");
            DropTable("Main.Orders");
            DropTable("Main.Products");
            DropTable("Main.MasterCategories");
            DropTable("Main.Categories");
        }
    }
}
