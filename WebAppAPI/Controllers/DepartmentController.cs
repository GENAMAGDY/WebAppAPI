using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAppAPI.Repositories;
using WebApplicationAPI.Models;

namespace WebAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Department>> Get()
        {
            return await _departmentRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<Department> Get(int id)
        {
            return await _departmentRepository.Get(id);
        }


        [HttpPost]
        public async Task<ActionResult<Department>> Post([FromBody] Department department)
        {
            var new_department = await _departmentRepository.Create(department);
            return CreatedAtAction(nameof(Get), new { id = new_department.Id });
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }
            await _departmentRepository.Update(department);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var departmentToDelete = await _departmentRepository.Get(id);
            if (departmentToDelete == null)
            {
                return NotFound();
            }
            await _departmentRepository.Delete(departmentToDelete.Id);
            return NoContent();
        }
    }
}
