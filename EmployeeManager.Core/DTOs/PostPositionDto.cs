using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Core.DTOs
{
    public class PostPositionDto
    {
        [Required(ErrorMessage = "Position Title is required")]
        public string PositionTitle { get; set; }
        [Required(ErrorMessage = "Hire Date is required")]
        public DateTime HireDate { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Must use a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Salary is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Salary can´t be less than 0")]
        public decimal Salary { get; set; }
    }
}
