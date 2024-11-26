using EmployeeManager.Core.DTOs;
using EmployeeManager.Core.Models;

namespace EmployeeManager.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<GetAllEmployeesDto>> GetAll();
        Task<Employee> GetById(int id);
        Task Save(Employee employee);
        Task Update(Employee employee);
        Task Delete(int id);
    }
}
