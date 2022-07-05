namespace Eticaret.Datacore.Migrations
{
    using Domain.Constants;
    using System;
    using System.Data.Entity.Migrations;

    public partial class sp_best_seller : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(DbCons.SpGetBestSeller.Name, x => new { cnt = x.Int() }, DbCons.SpGetBestSeller.Body);
        }
        
        public override void Down()
        {
            DropStoredProcedure(DbCons.SpGetBestSeller.Name);
        }
    }
}
