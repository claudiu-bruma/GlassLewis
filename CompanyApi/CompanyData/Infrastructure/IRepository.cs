using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CompanyData.Infrastructure
{
 
    public interface IRepository<TEntity>  where TEntity : class 
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void RefreshEntity(TEntity entity);
        TEntity GetById(int id);

        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where);
        int Count();
        int Count(Expression<Func<TEntity, bool>> where);
        List<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
    }
}
