using Eticaret.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basecore.Model.ResultTypes;
using Basecore.Data.EF;
using Eticaret.Domain.POCO;
using Eticaret.Datacore.Context;

namespace Eticaret.Konsol
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductRepository prepo = new ProductRepository();

            IUserRepository repo = new UserRepository(null);
            var activeUsers = repo.GetActiveUsers();


            
        }
    }
}
