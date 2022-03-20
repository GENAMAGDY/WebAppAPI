using Microsoft.EntityFrameworkCore;
using WebAppAPI.Models;
using WebApplicationAPI.Models;

namespace WebAppAPI.Repositories
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly DepartmentContext _context;

        public DepartmentRepository(DepartmentContext context)
        {
            _context = context;
        }
        public async Task<Department> Create(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task Delete(int id)
        {
            var departmentToDelete = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(departmentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> Get()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> Get(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task Update(Department department)
        {
            _context.Entry(department).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

       
    }
}
