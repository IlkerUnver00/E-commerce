using Basecore.Data;
using Basecore.Data.EF;
using Eticaret.Datacore.Context;
using Eticaret.Domain.POCO;
using Eticaret.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Infrastructure.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {

    }
    public class CustomerRepository : EFRepository<Customer, EticaretDbContext>,ICustomerRepository
    {
        public CustomerRepository(EticaretDbContext context) : base(context,Logger.LogRepositoryErrors)
        {
        }
    }
}
