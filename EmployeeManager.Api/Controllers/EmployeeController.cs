using EmployeeManager.Core.DTOs;
using EmployeeManager.Core.Services;
using Microsoft.AspNetCore.Mvc;
using EmployeeManager.Core.Exceptions;

namespace EmployeeManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _employeeService.GetById(id));
            }
            catch (NotFoundException)
            {
                return NotFound($"employee with ID {id} not found.");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] PostEmployeeDto postEmployeeDto)
        {
            if (postEmployeeDto == null)
            {
                return BadRequest("Employee cannot be null.");
            }
            try
            {
                await _employeeService.Save(postEmployeeDto);
                return Created();
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateEmployeeDto updateEmployeeDto)
        {
            if (updateEmployeeDto == null)
            {
                return BadRequest("Employee cannot be null.");
            }
            try
            {
                await _employeeService.Update(updateEmployeeDto);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound($"employee with ID {updateEmployeeDto.Id} not found.");
            }
        }
    }
}
