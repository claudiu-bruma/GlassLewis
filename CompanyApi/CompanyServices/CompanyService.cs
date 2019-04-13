using AutoMapper;
using CompanyData;
using CompanyData.Entities;
using CompanyData.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompanyServices
{
    public class CompanyService : ICompanyService
    {
        private IRepository<Company> companyRepo { get; set; }
        private IUnitOfWork unitOfWork { get; set; }
        public IMapper mapper { get; set; }
        public CompanyService(IRepository<Company> companyRepo, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.companyRepo = companyRepo;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public int Add(CompanyDto newCompany)
        {
            if (companyRepo.Query().Any(x => x.ISIN == newCompany.Isin))
            {
                throw new ArgumentException("Company Isin already exist");
            }
            var companyEntity = this.mapper.Map<Company>(newCompany);
            companyRepo.Add(companyEntity);
            unitOfWork.Commit();
            return companyEntity.Id;
        }

        public IEnumerable<CompanyDto> GetCompanies()
        {
            return this.companyRepo.Query().Select(x => new CompanyDto()
            {
                Exchange = x.Exchange,
                Id = x.Id,
                Isin = x.ISIN,
                Name = x.Name,
                StockTicker = x.StockTicker,
                Website = x.Website
            }
            );
        }

        public CompanyDto GetCompanyById(int id)
        {
            if (!companyRepo.Query().Any(x => x.Id == id))
            {
                throw new ArgumentException("Company Id does not exist");
            }
            return this.companyRepo.Query()
                .Where(x => x.Id == id)
                .Select(x =>
                    mapper.Map<CompanyDto>(x)
                ).FirstOrDefault();
        }

        public CompanyDto GetCompanyByIsin(string isin)
        {
            if (!companyRepo.Query().Any(x => x.ISIN == isin))
            {
                throw new ArgumentException("Company Isin does not exist");
            }
            return this.companyRepo.Query()
                .Where(x => x.ISIN == isin)
                .Select(x =>
                    mapper.Map<CompanyDto>(x)
                ).FirstOrDefault();
        }

        public void Update(CompanyDto companyDto)
        {

            if (!companyRepo.Query().Any(x => x.Id == companyDto.Id))
            {
                throw new ArgumentException("Company Id does not exist");
            }
            if ( companyRepo.Query().Any(x => x.Id != companyDto.Id && x.ISIN == companyDto.Isin))
            {
                throw new ArgumentException("Company with new Isin already exists");
            }
            var initialRecord = this.companyRepo.Query().Where(x => x.Id == companyDto.Id).FirstOrDefault();
            initialRecord.Exchange = companyDto.Exchange;
            initialRecord.ISIN = companyDto.Isin;
            initialRecord.Name  = companyDto.Name;
            initialRecord.StockTicker = companyDto.StockTicker;
            initialRecord.Website  = companyDto.Website;
            companyRepo.Update(initialRecord);
            unitOfWork.Commit();
        }
    }
}
