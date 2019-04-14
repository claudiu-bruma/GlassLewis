using CompanyData.Entities;
using CompanyServices;
using NUnit.Framework;

[SetUpFixture]
public class GlobalSetup
{
    [OneTimeSetUp]
    public void RunBeforeAnyTests()
    {
        // Executes once before the test run. (Optional)
        AutoMapper.Mapper.Initialize(config =>
        {
            config.CreateMap<Company, CompanyDto>();          
        }
  );
    }
    [OneTimeTearDown]
    public void RunAfterAnyTests()
    {
        // Executes once after the test run. (Optional)
    }
}
