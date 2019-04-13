using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CompanyData.Entities.Company, CompanyServices.CompanyDto>();
            CreateMap<CompanyServices.CompanyDto,CompanyData.Entities.Company  >();

        }
    }
}
