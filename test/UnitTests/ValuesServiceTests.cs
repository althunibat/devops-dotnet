using System.Collections.Generic;
using SampleApp.Api.Services;
using Shouldly;
using Xunit;

namespace WebApp.UnitTests
{
    public class ValuesServiceTests
    {
        [Fact]
        public void GetAllShouldReturnArray()
        {
            IValuesService service = new ValuesService();
            var values =
                service.GetAll();
            
            values.ShouldBe(GetValues());
        }
        
        
        [Fact]
        public void GetShouldReturnString()
        {
            IValuesService service = new ValuesService();
            var values =
                service.Get(1);
            
            values.ShouldBe(GetValue());
        }
        
        private static IEnumerable<string> GetValues()
        {
            return new[] {"value1", "value2"};
        }

        private string GetValue()
        {
            return "value";
        }
    }
}