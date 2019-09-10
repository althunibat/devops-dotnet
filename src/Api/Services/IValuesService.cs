using System.Collections.Generic;

namespace SampleApp.Api.Services
{
    public interface IValuesService
    {
        IEnumerable<string> GetAll();
        string Get(int id);
        
    }
}