using AutoMapper;
using EmployeeManager.Core.DTOs;
using EmployeeManager.Core.Exceptions;
using EmployeeManager.Core.Models;
using EmployeeManager.Core.Repositories;

namespace EmployeeManager.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) { 
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }    
        public async Task Delete(int id)
        {
            await _employeeRepository.Delete(id);
        }

        public async Task<IEnumerable<GetAllEmployeesDto>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<GetEmployeeDto> GetById(int id)
        {
            var employee= await _employeeRepository.GetById(id);
            if (employee == null)
            {
                throw new NotFoundException($"employee with ID {id} not found");
            }
            var employeeDto = _mapper.Map<GetEmployeeDto>(employee);
            var currentDate= DateTime.Now;
            int years = currentDate.Year - employee.Position.HireDate.Year;
            int months = currentDate.Month - employee.Position.HireDate.Month;
            if (months < 0)
            {
                years--;
                months += 12;
            }
            employeeDto.Position.TimeInPosition = years * 12 + months;
            return employeeDto;
        }

        public async Task Save(PostEmployeeDto postEmployeeDto)
        {
            var currentDate = DateTime.Now;
            if (postEmployeeDto.DateBirth > currentDate || postEmployeeDto.Position.HireDate > currentDate)
            {
                throw new ValidationException("Error validating Date");
            }
                
            var employee = _mapper.Map<Employee>(postEmployeeDto);
            await _employeeRepository.Save(employee);
        }

        public async Task Update(UpdateEmployeeDto updateEmployeeDto)
        {
            var employee =await  _employeeRepository.GetById(updateEmployeeDto.Id);
            if (employee == null)
            {
                throw new NotFoundException("Cannot update a non existent employee");
            }
            _mapper.Map(updateEmployeeDto, employee);
            await _employeeRepository.Update(employee);
        }
    }
}
