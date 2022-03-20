using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationAPI.Models;
using WebApplicationAPI.Repositories;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get() {
            return await _employeeRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            return await _employeeRepository.Get(id);
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> Post([FromBody] Employee employee)
        {
            var new_employee = await _employeeRepository.Create(employee);
            return CreatedAtAction(nameof(Get), new { id = new_employee.Id });
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            await _employeeRepository.Update(employee);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employeeToDelete = await _employeeRepository.Get(id);
            if(employeeToDelete== null)
            {
                return NotFound();
            }
            await _employeeRepository.Delete(employeeToDelete.Id);
            return NoContent();
        }
    }
}
