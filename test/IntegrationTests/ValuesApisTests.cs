using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace WebApp.IntegrationTests
{
    public class ValuesApisTests
    {
        private static readonly IDictionary Env = Environment.GetEnvironmentVariables();
        private static readonly string BaseAddress = $"http://{Env["SVC_HOST"] ?? "localhost:5000"}";

        [Fact]
        public async Task GetReturnJsonArray()
        {
            // arrange
            using (var client = new HttpClient(new HttpClientHandler(), false)
            {
                BaseAddress = new Uri(BaseAddress)
            })
            {
                // Act
                var httpResponseMessage = await client.GetAsync("/api/values");

                // Assert
                httpResponseMessage.IsSuccessStatusCode.ShouldBeTrue();
                var res = await httpResponseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert
                    .DeserializeObject<List<string>>(res);
                data.Count.ShouldBePositive();
            }
        }
        [Fact]
        public async Task GetByIdReturnValueString()
        {
            // arrange
            using (var client = new HttpClient(new HttpClientHandler(), false)
            {
                BaseAddress = new Uri(BaseAddress)
            })
            {
                // Act
                var httpResponseMessage = await client.GetAsync("/api/values/1");

                // Assert
                httpResponseMessage.IsSuccessStatusCode.ShouldBeTrue();
                var res = await httpResponseMessage.Content.ReadAsStringAsync();
                res.ShouldNotBeEmpty();
            }
        }
    }
}