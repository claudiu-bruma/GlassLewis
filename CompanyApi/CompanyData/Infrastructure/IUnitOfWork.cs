using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyData.Infrastructure
{
    public interface IUnitOfWork 
    {
        void Commit();
    }
}
