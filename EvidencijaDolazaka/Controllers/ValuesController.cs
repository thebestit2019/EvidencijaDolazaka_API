using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvidencijaDolazaka.models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EvidencijaDolazaka.Controllers
{
    [Route("/empCont")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public ControllContext Context { get; set; }
        public JsonSerializerSettings JsonSer { get; set; }

        public ValuesController(){
            Context = new ControllContext();
            JsonSer = new JsonSerializerSettings() {Formatting = Formatting.Indented};
        }
        // GET api/values
        [HttpGet]
        [Route("/{pin}")]
        [DisableCors]
        public JsonResult GetAllEmployees(int pin)
        {
            var res = from Employee in Context.employee where Employee.Pin == pin select Employee;

            return new JsonResult(res, JsonSer);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
