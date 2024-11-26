using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Core.Models
{
    public class Position
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee Id Title is required")]
        public int EmployeeId { get; set; }
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
