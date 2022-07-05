using Basecore.Data;
using Basecore.Data.EF;
using Eticaret.Datacore.Context;
using Eticaret.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Infrastructure.Repositories
{
    public interface IBasketRepository : IRepository<Basket>
    {

    }
    public class BasketRepository : EFRepository<Basket, EticaretDbContext>, IBasketRepository
    {
        public BasketRepository(EticaretDbContext context) : base(context, Logging.Logger.LogRepositoryErrors)
        {

        }
    }
}
