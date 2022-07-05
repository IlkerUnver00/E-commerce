namespace Eticaret.Datacore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Main.Customers", "Name", c => c.String(maxLength: 100));
            AlterColumn("Main.Customers", "Surname", c => c.String(maxLength: 100));
            AlterColumn("Main.Customers", "Address", c => c.String(maxLength: 500));
            AlterColumn("Main.Customers", "City", c => c.String(maxLength: 100));
            AlterColumn("Main.Customers", "Country", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("Main.Customers", "Country", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("Main.Customers", "City", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("Main.Customers", "Address", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("Main.Customers", "Surname", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("Main.Customers", "Name", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
