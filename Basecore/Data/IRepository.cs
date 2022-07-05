using Basecore.Model;
using Basecore.Model.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Basecore.Data
{
    public interface IRepository<T> : IDisposable
        where T : IBaseModel
    {
        EntityResult<List<T>> GetList(Expression<Func<T,bool>> filter = null);
        EntityResult<T> Get(Expression<Func<T,bool>> filter);
        EntityResult Insert(T entity);
        EntityResult<T> InsertGet(T entity);
        EntityResult Delete(T entity);
        EntityResult Update(T entity);
    }
}
