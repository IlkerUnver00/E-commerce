using Basecore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basecore.Model.ResultTypes;
using System.Linq.Expressions;
using Basecore.Model.Constants;
using Basecore.Helper;

namespace Basecore.Data.EF
{
    public class EFRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : BaseModel
        where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly Action<Exception> logHandler;
        public EFRepository(TContext context, Action<Exception> logger)
        {
            Context = context;
            logHandler = logger;
        }

        public EntityResult Delete(TEntity entity)
        {
            EntityResult result = null;
            try
            {
                Context.Set<TEntity>().Remove(entity);
                if (Context.SaveChanges() > 0)
                {
                    result = new EntityResult();
                }
                else
                {
                    result = new EntityResult("Silme işlemi tamamlanamadı.", ResultStatus.Warning);
                }
            }
            catch (Exception ex)
            {
                var innest = ex.ToInnest();
                logHandler(innest);
                result = new EntityResult(innest.Message, ResultStatus.Error);
            }
            return result;
        }

        public EntityResult<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            EntityResult<TEntity> result = null;
            try
            {
                var entity = Context.Set<TEntity>().AsNoTracking().SingleOrDefault(filter);
                if (entity != null)
                {
                    result = new EntityResult<TEntity>(entity);
                }
                else
                {
                    result = new EntityResult<TEntity>(null, "Bu kayıt bulunamadı.", ResultStatus.NotFound);
                }

            }
            catch (Exception ex)
            {
                var innest = ex.ToInnest();
                logHandler(innest);
                result = new EntityResult<TEntity>(null, innest.Message, ResultStatus.Error);
            }
            return result;
        }

        public EntityResult<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            EntityResult<List<TEntity>> result = null;
            try
            {
                List<TEntity> entities = new List<TEntity>();
                if (filter != null)
                    entities = Context.Set<TEntity>().AsNoTracking().Where(filter).ToList();
                else
                    entities = Context.Set<TEntity>().ToList();
                result = new EntityResult<List<TEntity>>(entities);
            }
            catch (Exception ex)
            {
                var innest = ex.ToInnest();
                logHandler(innest);
                result = new EntityResult<List<TEntity>>(null, innest.Message, ResultStatus.Error);
            }
            return result;
        }

        public EntityResult Insert(TEntity entity)
        {
            EntityResult result = null;
            try
            {
                Context.Set<TEntity>().Add(entity);
                if (Context.SaveChanges() > 0)
                {
                    result = new EntityResult();
                }
                else
                {
                    result = new EntityResult("insert-error", ResultStatus.Warning);
                }
            }
            catch (Exception ex)
            {
                var innest = ex.ToInnest();
                logHandler(innest);
                result = new EntityResult(innest.Message, ResultStatus.Error);
            }

            return result;
        }

        public EntityResult<TEntity> InsertGet(TEntity entity)
        {
            EntityResult<TEntity> result = null;
            try
            {
                var ent = Context.Set<TEntity>().Add(entity);
                if (Context.SaveChanges() > 0)
                {
                    result = new EntityResult<TEntity>(ent);
                }
                else
                {
                    result = new EntityResult<TEntity>(null, "insert-get-error", ResultStatus.Warning);
                }
            }
            catch (Exception ex)
            {
                var innest = ex.ToInnest();
                logHandler(innest);
                result = new EntityResult<TEntity>(null,innest.Message, ResultStatus.Error);
            }
            return result;
        }

        public EntityResult Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
        private void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                //Unmanaged resource
                
                Disposed = true;
            }
        }
        private bool Disposed { get; set; }

    }
}
