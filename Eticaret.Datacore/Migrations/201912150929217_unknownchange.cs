namespace Eticaret.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unknownchange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Baskets", newName: "Basket");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Basket", newName: "Baskets");
        }
    }
}
