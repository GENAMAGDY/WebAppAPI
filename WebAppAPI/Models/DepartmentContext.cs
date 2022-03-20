using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;

namespace WebAppAPI.Models
{
    public class DepartmentContext:DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Department> Departments { get; set; }
    }
}
