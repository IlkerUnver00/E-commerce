using Basecore.Data;
using Basecore.Data.EF;
using Eticaret.Datacore.Context;
using Eticaret.Domain.Constants;
using Eticaret.Domain.POCO;
using Eticaret.Domain.SpResults;
using Eticaret.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {


        List<Product> GetNewArrivals(int categoryid = -1, int count = 4);
        List<Product> GetBestSellers(int count = 4);
        List<Product> TopProducts(int count);

        List<Product> GetProductsByCustomerId(int customerId);
        IQueryable<Product> GetProductsByCategoryId(int selectedCategoryId = 0);

    }

    public class ProductRepository : EFRepository<Product, EticaretDbContext>, IProductRepository
    {
        public ProductRepository(EticaretDbContext ctx) : base(ctx, Logger.LogRepositoryErrors)
        {

        }

        public override void Dispose()
        {
            base.Dispose();
            GC.SuppressFinalize(this);
        }
        

        public List<Product> GetBestSellers(int count = 4)
        {
            //var orderproducts = Context.Database.SqlQuery<dynamic>(query).GroupBy(x => x.ProductId).OrderByDescending(x => x.Count()).Take(4).Select(x =>x.Key).ToList();
            var orderproducts = Context.Database.SqlQuery<BestSellerProduct>(DbCons.SpGetBestSeller.Name+ " @cnt", new SqlParameter("cnt",count)).ToList();
            List<Product> result = new List<Product>();
            foreach (var item in orderproducts)
            {
                result.Add(Context.Products.SingleOrDefault(x => x.Id == item.ProductId && x.IsActive && !x.IsDeleted));
            }
            return result;
        }

        public List<Product> GetNewArrivals(int categoryid = -1, int count = 4)
        {
            List<Product> products = new List<Product>();
            try
            {
                if (categoryid == -1)
                {
                    products = Context.Products.Where(x => x.IsActive && !x.IsDeleted).OrderByDescending(x => x.Created).Take(count).ToList();
                }
                else
                {
                    products = Context.Products.Where(x => x.IsActive && !x.IsDeleted && x.CategoryId == categoryid).OrderByDescending(x => x.Created).Take(count).ToList();
                }

            }
            catch (Exception ex)
            {
                logHandler(ex);
            }
            return products;
        }

        public IQueryable<Product> GetProductsByCategoryId(int selectedCategoryId = 0)
        {
            IQueryable<Product> result = null;
            if (selectedCategoryId==0)
            {
                result = Context.Products.AsQueryable();
            }
            else
            {
                var query = $"Select * from {DbCons.Products.NameWithSch} where CategoryId in (Select Id from {DbCons.Categories.NameWithSch} where MasterCategoryId in(Select Id from {DbCons.MasterCategories.NameWithSch} where Id={selectedCategoryId}))";
                result = Context.Products.SqlQuery(query).AsQueryable();
            }
            return result;
        }

        public List<Product> GetProductsByCustomerId(int customerId)
        {
            var products = Context.Products.SqlQuery($"Select * from {DbCons.Products.NameWithSch} where Id in(Select ProductId from dbo.Baskets where CustomerId={customerId})");
            return products.ToList();
        }

        public List<Product> TopProducts(int count)
        {
            return Context.Products.OrderByDescending(x => x.Created).Take(count).ToList();
        }
    }
}
