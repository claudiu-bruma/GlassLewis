using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyData.Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly CompanyDbContext context;

        public UnitOfWork(CompanyDbContext context)
        {
            this.context = context;
        }


        public void Commit()
        {
            try
            {
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
