using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SampleApp.Api.Controllers;
using SampleApp.Api.Services;
using Shouldly;
using Xunit;

namespace WebApp.UnitTests
{
    public class ValuesControllerTests
    {
        [Fact]
        public void GetReturnValuesArray()
        {
            var mockService = new Mock<IValuesService>();
            mockService.Setup(service => service.GetAll())
                .Returns(GetValues);
            var controller = new ValuesController(mockService.Object);

            var ops = controller.Get();
            var result = ops.Result.ShouldBeAssignableTo<OkObjectResult>();
            result.Value.ShouldBe(GetValues());
        }
        
        [Fact]
        public void GetByIdReturnValueString()
        {
            var mockService = new Mock<IValuesService>();
            mockService.Setup(service => service.Get(1))
                .Returns(GetValue);
            var controller = new ValuesController(mockService.Object);

            var ops = controller.Get(1);
            var result = ops.Result.ShouldBeAssignableTo<OkObjectResult>();
            result.Value.ShouldBe(GetValue());
        }
        
        [Fact]
        public void PostValueReturnCreatedAt()
        {
            var mockService = new Mock<IValuesService>();
            var controller = new ValuesController(mockService.Object);

            var ops = controller.Post("value");
            var result = ops.ShouldBeAssignableTo<CreatedAtRouteResult>();
            result.StatusCode.HasValue.ShouldBeTrue();
            result.StatusCode.ShouldBe((int) HttpStatusCode.Created);
        }
        
        [Fact]
        public void PutValueReturnNoContent()
        {
            var mockService = new Mock<IValuesService>();
            var controller = new ValuesController(mockService.Object);

            var ops = controller.Put(1,"value");
            var result = ops.ShouldBeAssignableTo<NoContentResult>();
            result.StatusCode.ShouldBe((int) HttpStatusCode.NoContent);
        }
        
        [Fact]
        public void DeleteValueReturnNoContent()
        {
            var mockService = new Mock<IValuesService>();
            var controller = new ValuesController(mockService.Object);

            var ops = controller.Delete(1);
            var result = ops.ShouldBeAssignableTo<NoContentResult>();
            result.StatusCode.ShouldBe((int) HttpStatusCode.NoContent);
        }

        private static IEnumerable<string> GetValues()
        {
            return new[] {"value1", "value2"};
        }

        private static string GetValue()
        {
            return "value";
        }
    }
}