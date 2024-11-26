using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Core.DTOs
{
    public class GetPositionDto
    {
        public string PositionTitle { get; set; }
        public DateTime HireDate { get; set; }
        [EmailAddress(ErrorMessage = "Must use a valid email address")]
        public string Email { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary can´t be less than 0")]
        public decimal Salary { get; set; }
        public int TimeInPosition { get; set; }
    }
}
