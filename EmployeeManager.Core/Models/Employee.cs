using System.ComponentModel.DataAnnotations;
using EmployeeManager.Core.Validators;

namespace EmployeeManager.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, MinimumLength = 3,ErrorMessage ="First name need at least 3 characters and no more than 20")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Middle Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Middle name need at least 3 characters and no more than 20")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Last name need at least 3 characters and no more than 20")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Location City is required")]
        [ValidCity]
        public string LocationCity { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^street \d+, [A-Za-z\s]+, [A-Za-z\s]+$", ErrorMessage = "address must follow format: street {street number}, {city}, {country}")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Date Birth is required")]
        public DateTime DateBirth { get; set; }
        [Required(ErrorMessage = "Telephone is required")]
        [Phone]
        public string Telephone { get; set; }
        [Required(ErrorMessage ="Status is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Position is required")]
        public Position Position { get; set; }
    }
}
