using System.Collections.Generic;

namespace SampleApp.Api.Services
{
    public class ValuesService:IValuesService
    {
        public IEnumerable<string> GetAll()
        {
            return new[] {"value1", "value2"};
        }

        public string Get(int id)
        {
            return "value";
        }
    }
}