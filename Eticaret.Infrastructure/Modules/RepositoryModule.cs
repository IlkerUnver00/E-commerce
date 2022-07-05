using Eticaret.Domain.POCO;
using Eticaret.Infrastructure.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Infrastructure.Modules
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            Bind<IProductRepository>().To<ProductRepository>().InSingletonScope();
            Bind<ICustomerRepository>().To<CustomerRepository>().InSingletonScope();
            Bind<ICategoryRepository>().To<CategoryRepository>().InSingletonScope();
            Bind<IBasketRepository>().To<BasketRepository>().InSingletonScope();
            Bind<IMasterCategoryRepository>().To<MasterCategoryRepository>().InSingletonScope();
        }
    }
}
