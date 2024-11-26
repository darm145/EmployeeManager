using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Core.DTOs
{
    public class UpdatePositionDto
    {
        [EmailAddress(ErrorMessage = "Must use a valid email address")]
        public string Email { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary can´t be less than 0")]
        public decimal Salary { get; set; }
    }
}
