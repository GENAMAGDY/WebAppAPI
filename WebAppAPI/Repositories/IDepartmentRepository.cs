using WebApplicationAPI.Models;

namespace WebAppAPI.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> Get();
        Task<Department> Get(int id);
        Task<Department> Create(Department employee);
        Task Update(Department employee);
        Task Delete(int id);
    }
}
