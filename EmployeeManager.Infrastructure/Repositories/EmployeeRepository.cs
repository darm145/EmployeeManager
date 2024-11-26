using EmployeeManager.Core.DTOs;
using EmployeeManager.Core.Models;
using EmployeeManager.Core.Repositories;
using EmployeeManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace EmployeeManager.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetAllEmployeesDto>> GetAll()
        {
            return await _context.Employees.Include(p => p.Position)
                .Select( e =>
                
                new GetAllEmployeesDto
                {
                    EmployeeId = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    PositionTitle = e.Position.PositionTitle,
                    Status = e.Status,
                    DateArrival = e.Position.HireDate,
                }
            ).ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.Include(p => p.Position)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Save(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
