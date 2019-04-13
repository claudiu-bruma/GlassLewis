using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyData;
using CompanyData.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompanyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        public CompanyDbContext CompanyDbContext { get; set; }
        public CompanyController(CompanyDbContext context)
        {
            CompanyDbContext = context;
        }
        // GET: api/Company
        [HttpGet]
        public IEnumerable<Company> Get()
        {
            return CompanyDbContext.Companies.ToList();

            //return new string[] { "value1", "value2" };
        }

        // GET: api/Company/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Company
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Company/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
