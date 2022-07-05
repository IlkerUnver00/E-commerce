using Basecore.Data;
using Basecore.Data.EF;
using Basecore.Helper;
using Basecore.Model.Constants;
using Basecore.Model.ResultTypes;
using Eticaret.Datacore.Context;
using Eticaret.Domain.Constants;
using Eticaret.Domain.POCO;
using Eticaret.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eticaret.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        EntityResult<List<ApplicationUser>> GetActiveUsers();

        EntityResult<List<ApplicationUser>> GetUsersByRole(Role role);

        EntityResult<ApplicationUser> Login(string email, string password);
    }

    public class UserRepository : EFRepository<ApplicationUser, EticaretDbContext>, IUserRepository
    {
        public UserRepository(EticaretDbContext context) : base(context, Logger.LogRepositoryErrors)
        {

        }

        public EntityResult<List<ApplicationUser>> GetActiveUsers()
        {
            EntityResult<List<ApplicationUser>> result = null;
            try
            {
                var users = Context.Users.AsNoTracking().Where(x => x.IsActive && !x.IsDeleted).ToList();
                if (users.Any())
                {
                    result = new EntityResult<List<ApplicationUser>>(users);
                }
                else
                {
                    result = new EntityResult<List<ApplicationUser>>(null, "not-found", ResultStatus.NotFound);
                }
            }
            catch (Exception ex)
            {
                var innest = ex.ToInnest();
                logHandler(innest);
                result = new EntityResult<List<ApplicationUser>>(null, innest.Message, ResultStatus.Error);
            }
            return result;
        }

        public EntityResult<List<ApplicationUser>> GetUsersByRole(Role role)
        {
            EntityResult<List<ApplicationUser>> result = null;
            try
            {
                var users = Context.Users.SqlQuery($"Select * from {DbCons.Users.NameWithSch} where Id in(Select UserId from {DbCons.UserRoles.NameWithSch} where RoleId=@roleid)", new SqlParameter("@roleid", role.Id)).ToList();
                if (users.Any())
                {
                    result = new EntityResult<List<ApplicationUser>>(users);
                }
                else
                {
                    result = new EntityResult<List<ApplicationUser>>(null, "not-found", ResultStatus.NotFound);
                }
            }
            catch (Exception ex)
            {
                var innest = ex.ToInnest();
                logHandler(innest);
                result = new EntityResult<List<ApplicationUser>>(null, innest.Message, ResultStatus.Error);
            }
            return result;
        }

        public EntityResult<ApplicationUser> Login(string email, string password)
        {
            EntityResult<ApplicationUser> result = null;
            try
            {
                var user = Context.Users.SingleOrDefault(x => x.IsActive && !x.IsDeleted && x.Email == email && x.Password == password);
                if (user!=null)
                {
                    result = new EntityResult<ApplicationUser>(user);
                }
                else
                {
                    result = new EntityResult<ApplicationUser>(null, "Beni ara", ResultStatus.Warning);
                }

            }
            catch (Exception ex)
            {
                var innest = ex.ToInnest();
                logHandler(innest);
                result = new EntityResult<ApplicationUser>(null, innest.Message, ResultStatus.Error);
            }
            return result;
        }
    }
}
