using CompanyData;
using CompanyData.Entities;
using CompanyData.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyServices
{
    public class CompanyService : ICompanyService
    {
        public IRepository<Company> companyRepo { get; set; }
        public CompanyService(IRepository<Company> companyRepo)
        {
            this.companyRepo = companyRepo;
        }
        public void Add(CompanyDto newCompany)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CompanyDto> GetCompanies()
        {
            throw new NotImplementedException();
        }

        public CompanyDto GetCompanyById(int id)
        {
            throw new NotImplementedException();
        }

        public CompanyDto GetCompanyByIsin(string Isin)
        {
            throw new NotImplementedException();
        }

        public void Update(CompanyDto companyDto)
        {
            throw new NotImplementedException();
        }
    }
}
