using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EvidencijaDolazaka.models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EvidencijaDolazaka.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public ControllContext Context {get; set;}
        public JsonSerializerSettings JsonSer { get; set; }

        public ValuesController(){
            Context = new ControllContext();
            JsonSer = new JsonSerializerSettings() {Formatting = Formatting.Indented};
        }
        
        // GET values/{id} - sends full worker object with given pin
        [HttpGet]
        [Route("emp/{pin}")]
        [Produces("application/json")]
        public JsonResult Get(int pin)
        {
            //var res = from Employee in Context.employee where Employee.Pin == id select Employee;
            var em = Context.employee.Where(e => e.Pin == pin);
            return new JsonResult(em, JsonSer) ;
        }
       
       // GET values/allPins - returns all pins from database
       
        [Route("allPins")]
        public JsonResult GetAllPins(){
            var pins = from Employee in Context.employee select Employee.Pin;

            return new JsonResult(pins, JsonSer);
        }

        public class dataJson{
            public string Jmbg {get; set;}
            public string Datum {get; set;}
            public string VremeDolaska {get; set;}
        }

        // POST api/values
        [HttpPost]
        [Route("post")]

        public IActionResult Post(dataJson data)
        {
            if(ModelState.IsValid){
            var contextForTime = new ControllContext();
            
            var newTimeEntry = new Time {
                
                Datum = Convert.ToDateTime(data.Datum),
                VremeDolaska = TimeSpan.Parse(data.VremeDolaska),
                VremeOdlaska = TimeSpan.Parse("14:00"),
                Slika1 = "neka slika1",
                Slika2 = "neka slika2",
                Radnik = data.Jmbg
            };

            contextForTime.Add(newTimeEntry);
            contextForTime.SaveChanges();

            return Ok();
            }else{
                return BadRequest();
            }
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
