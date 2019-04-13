using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyServices
{
    public interface ICompanyService
    {
        void Add(CompanyDto newCompany);
        CompanyDto GetCompanyById(int id);
        CompanyDto GetCompanyByIsin(string Isin);
        IEnumerable<CompanyDto> GetCompanies();
        void Update(CompanyDto companyDto);

    }
}
