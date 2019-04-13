using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CompanyData.Infrastructure
{
    public class Repository<TEntity > : IRepository<TEntity >
    where TEntity : class 
    {
        private readonly CompanyDbContext dataContext;

        public Repository(CompanyDbContext  context)
        {
            this.dataContext = context;
        }

        public void Add(TEntity entity)
        {
            dataContext.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dataContext.Set<TEntity>().Update(entity);
          //  dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            dataContext.Set<TEntity>().Remove(entity);
        }

        public virtual TEntity GetById(int id)
        {
            return dataContext.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Query( )
        {
            return dataContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> where )
        {
            return Query().Where(where);
        }

        public int Count()
        {
            return dataContext.Set<TEntity>().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> where)
        {
            return dataContext.Set<TEntity>().Count(where);
        }

        public List<TEntity> GetMany(Expression<Func<TEntity, bool>> where)
        {
            return dataContext.Set<TEntity>().Where(where).ToList();
        }

        public void RefreshEntity(TEntity entity)
        {
            dataContext.Entry<TEntity>(entity).Reload();
        }
    }
}
