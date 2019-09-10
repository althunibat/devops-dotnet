using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SampleApp.Api.Services;

namespace SampleApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesService _service;

        public ValuesController(IValuesService service)
        {
            _service = service;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_service.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}",Name="GetById")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_service.Get(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            return CreatedAtRoute("GetById", 1, null);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}