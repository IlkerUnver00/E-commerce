namespace Eticaret.Datacore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Eticaret.Datacore.Context.EticaretDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Eticaret.Datacore.Context.EticaretDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(x => x.Email, new Domain.POCO.ApplicationUser
            {
                Email = "superadmin@email.com",
                Password = "123",
                FullName = "Admin User",
            });
            var folder = @"C:\Users\vektorel\Desktop\11 Ocak 2020\Vektorel.Eticaret\Eticaret.MVC.UI\bin\Mock\";

            var categories = File.ReadAllText(folder + "categories.sql");
            var products = File.ReadAllText(folder + "products.sql");
            var mastercategories = File.ReadAllText(folder + "mastercategories.sql");
            var customers = File.ReadAllText(folder + "customers.sql");
            var orders = File.ReadAllText(folder + "orders.sql");

            try
            {
                context.Database.ExecuteSqlCommand(mastercategories);
            }
            catch (Exception)
            {
            }
            try
            {
                context.Database.ExecuteSqlCommand(categories);
            }
            catch (Exception)
            {
            }
            try
            {
                context.Database.ExecuteSqlCommand(products);
            }
            catch (Exception)
            {
            }
            try
            {
                context.Database.ExecuteSqlCommand(customers);
            }
            catch (Exception)
            {
            }
            try
            {
                context.Database.ExecuteSqlCommand(orders);
            }
            catch (Exception)
            {
            }

            context.SaveChanges();
        }
    }
}
