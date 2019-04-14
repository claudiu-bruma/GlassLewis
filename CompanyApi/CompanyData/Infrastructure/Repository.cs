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
        }




        public IQueryable<TEntity> Query( )
        {
            return dataContext.Set<TEntity>();
        }

        public int Count()
        {
            return dataContext.Set<TEntity>().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> where)
        {
            return dataContext.Set<TEntity>().Count(where);
        }



    }
}
