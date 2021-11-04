using BankGateWay.Models;
using BankGateWay.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankGateWay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeLoginService _service;

        public EmployeeController(EmployeeLoginService service)
        {
            _service = service;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ActionResult<EmployeeLoginDto>> Post([FromBody] EmployeeLoginDto loginDto)
        {
            EmployeeLoginDto loginDto1 = _service.Register(loginDto);
            if (loginDto1 != null)
            {
                return Ok(loginDto1);
            }
            return BadRequest("ID Already Exists");
        }
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<EmployeeLoginDto>> Login([FromBody] EmployeeLoginDto loginDto)
        {
            EmployeeLoginDto dto = _service.Login(loginDto);
            if (dto != null)
            {
                return dto;
            }
            return BadRequest("Invalid User");
        }
        // PUT api/<EmployeeController>/5
        [HttpPut("{Employeeid}")]
        public void Put(int Employeeid, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
