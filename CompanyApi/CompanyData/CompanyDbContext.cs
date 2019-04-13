using CompanyData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyData
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
                
        }
        public virtual DbSet<Company> Companies { get; set; }

    }
}
