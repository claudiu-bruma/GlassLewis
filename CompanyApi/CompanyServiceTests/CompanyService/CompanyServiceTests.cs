using CompanyData.Entities;
using CompanyData.Infrastructure;
using CompanyServices;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentAssertions;

namespace CompanyServiceTests 
{
    [TestFixture]
    public class CompanyServiceTests
    {
        private MockRepository mockRepository;
        private Mock<IRepository<Company>> mockCompanyRepo;
        private List<Company> companyList;

        [SetUp]
        public void SetUp()
        {

            companyList.Add(new Company()
            {
                Exchange = "NASDAQ",
                Id  = 1 , 
                ISIN = "US123123",
                Name = "Company1",
                StockTicker = "cmp1"                
            });
            companyList.Add(new Company()
            {
                Exchange = "NASDAQ",
                Id =2,
                ISIN = "EU434434434",
                Name = "Company1",
                StockTicker = "dddd"
            });
            //this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockCompanyRepo = new Mock<IRepository<Company>>();
            mockCompanyRepo.Setup(x=>x.Query(It.IsAny<Expression<Func<Company, bool>>>())).Returns(companyList.AsQueryable());
            mockCompanyRepo.Setup(d => d.Add(It.IsAny<Company>())).Callback<Company>((s) => { s.Id = companyList.Max(x => x.Id) + 1; companyList.Add(s); });
            mockCompanyRepo.Setup(d => d.Update(It.IsAny<Company>())).Callback<Company>((s) =>
            {
                var oldItem = companyList.FirstOrDefault(x => x.Id == s.Id);
                oldItem = s;
            });



        }

        [TearDown]
        public void TearDown()
        {
            this.mockRepository.VerifyAll();
        }

        private CompanyService CreateService()
        {
            return new CompanyService(mockCompanyRepo.Object);
        }

        [Test]
        public void Add_AddInValidCompanyWithExistingIsin_ArgumentException()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            CompanyDto newCompany = new CompanyDto(){
                 Exchange = "aaaaa",
                 Isin = "US123123",
                 Website = "www.coconut.com",
                 Name ="addedCompany",
                 StockTicker = "stkT"

            }; 
            // Assert
            unitUnderTest.Invoking(y => y.Add(
              newCompany)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void Add_AddValidCompany_CompanyIsAdded()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            CompanyDto newCompany = new CompanyDto()
            {
                Exchange = "aaaaa",
                Isin = "US54534534545555",
                Website = "www.coconut.com",
                Name = "addedCompany",
                StockTicker = "stkT"

            };

            // Act
            unitUnderTest.Add(
                newCompany);

            // Assert
            companyList.FirstOrDefault(x => x.ISIN == newCompany.Isin).Should().NotBeNull();

        }

        [Test]
        public void GetCompanies_CompaniesExist_AllCompaniesReturned()
        {
            // Arrange
            var unitUnderTest = this.CreateService();

            // Act
            var result = unitUnderTest.GetCompanies();

            // Assert
            result.Should().BeSameAs(companyList.Select(x=>new CompanyDto()
            {
                Exchange = x.Exchange,
                Id = x.Id,
                Isin = x.ISIN,
                Name = x.Name,
                StockTicker = x.StockTicker,
                Website = x.Website
            }
                ));
        }
        [Test]
        public void GetCompanies_NoCompaniesExistEmptyListReturned()
        {
            // Arrange
            var unitUnderTest = this.CreateService();

            // Act
            var result = unitUnderTest.GetCompanies();

            // Assert
            result.Should().BeEmpty();
        }
        [Test]
        public void GetCompanyById_IdExists_CorrectCompanyRetuirned()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            int id = 1;

            // Act
            var result = unitUnderTest.GetCompanyById(
                id);

            // Assert
            result.Should().NotBeNull();
        }
        [Test]
        public void GetCompanyById_IdDoesNotExists_NullExceptionReturned()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            int id = 1;

            // Act
            var result = unitUnderTest.GetCompanyById(
                id);

            // Assert
            unitUnderTest.Invoking(y => y.GetCompanyById(
                id)).Should().Throw<ArgumentException>();
        }
        [Test]
        public void GetCompanyByIsin_IsinExists_CorrectCompanyRetuirned()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            string Isin = "US123123";

            // Act
            var result = unitUnderTest.GetCompanyByIsin(
                Isin);

            // Assert
            result.Should().NotBeNull();
        }
        [Test]
        public void GetCompanyByIsin_IsinDoesNotExists_NullExceptionReturned()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            string Isin = "US123123";

            // Act
            var result = unitUnderTest.GetCompanyByIsin(
                Isin);

            // Assert
            unitUnderTest.Invoking(y => y.GetCompanyByIsin(
                 Isin)).Should().Throw<ArgumentException>();
        }

        [Test]
        public void Update_CompanyExists_FieldsCorrectlyUpdated()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            CompanyDto companyDto = new CompanyDto()
            {
                Exchange = "aaaaa",
                Isin = "US123123",
                Website = "www.coconut.com",
                Name = "addedCompany",
                StockTicker = "stkT",
                Id=1

            };

            // Act
            unitUnderTest.Update(
                companyDto);

            // Assert
            Assert.Fail();
        }

        [Test]
        public void Update_CompanyExists_InvalidFieldsNotSaved()
        {
            // Arrange
            var unitUnderTest = this.CreateService();
            CompanyDto companyDto = new CompanyDto()
            {
                Exchange = "aaaaa",
                Isin = "U123123",
                Website = "www.coconut.com",
                Name = "addedCompany",
                StockTicker = "stkT",
                Id = 1

            };

            // Act

            unitUnderTest.Invoking(y => y.Update(
     companyDto)).Should().Throw<ArgumentException>();

            // Assert
            companyList.FirstOrDefault(x => x.Id == companyDto.Id).ISIN.Should().NotBe(companyDto.Isin);
        }
    }
}
