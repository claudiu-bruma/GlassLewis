using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CompanyData;
using CompanyData.Entities;
using CompanyServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        ICompanyService companyService;
        IMapper mapper;
        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            this.companyService = companyService;
            this.mapper = mapper;
        }
        // GET: api/Company
        [HttpGet]
        public IEnumerable<CompanyDto> Get()
        {
            return companyService.GetCompanies();
        }

        // GET: api/Company/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<CompanyDto> Get(int id)
        {
            try
            {
                return companyService.GetCompanyById(id);
            }
            catch (ArgumentException aex)
            {
                return NotFound(aex.Message);
            }

        }

        [HttpGet("{id}", Name = "Get")]
        public ActionResult<CompanyDto> Get(string isin)
        {
            try
            {
                return companyService.GetCompanyByIsin(isin);
            }
            catch (ArgumentException aex)
            {
                return NotFound(aex.Message);
            }
        }
        // POST: api/Company
        [HttpPost]
        public int Post([FromBody] CompanyDto company)
        {

            return companyService.Add(company);
        }

        // PUT: api/Company 
        [HttpPut]
        public void Put([FromBody]  CompanyDto company)
        {
            companyService.Update(company);
        }


    }
}
