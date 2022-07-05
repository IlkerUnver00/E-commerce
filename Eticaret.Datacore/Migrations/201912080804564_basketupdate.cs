namespace Eticaret.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basketupdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Baskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.String(maxLength: 200),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Updated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Main.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("Main.Products", t => t.ProductId)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductId);
            
            AddColumn("Main.Customers", "IpAddress", c => c.String(maxLength: 200));
            AddColumn("Main.Customers", "Key", c => c.String(maxLength: 200));
            AddColumn("Main.Customers", "UserId", c => c.Int());
            CreateIndex("Main.Customers", "UserId");
            AddForeignKey("Main.Customers", "UserId", "Management.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Baskets", "ProductId", "Main.Products");
            DropForeignKey("dbo.Baskets", "CustomerId", "Main.Customers");
            DropForeignKey("Main.Customers", "UserId", "Management.Users");
            DropIndex("Main.Customers", new[] { "UserId" });
            DropIndex("dbo.Baskets", new[] { "ProductId" });
            DropIndex("dbo.Baskets", new[] { "CustomerId" });
            DropColumn("Main.Customers", "UserId");
            DropColumn("Main.Customers", "Key");
            DropColumn("Main.Customers", "IpAddress");
            DropTable("dbo.Baskets");
        }
    }
}
