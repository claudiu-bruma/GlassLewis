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
        IQueryable<TEntity> Query();     
        int Count();
        int Count(Expression<Func<TEntity, bool>> where);
     
    }
}
