using EmployeeManager.Core.DTOs;
using EmployeeManager.Core.Models;

namespace EmployeeManager.Core.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<GetAllEmployeesDto>> GetAll();
        Task<GetEmployeeDto> GetById(int id);
        Task Save(PostEmployeeDto postEmployeeDto);
        Task Update(UpdateEmployeeDto updateEmployeeDto);
        Task Delete(int id);
    }
}
