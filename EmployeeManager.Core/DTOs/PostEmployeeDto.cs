using System.ComponentModel.DataAnnotations;
using EmployeeManager.Core.Models;
using EmployeeManager.Core.Validators;

namespace EmployeeManager.Core.DTOs
{
    public class PostEmployeeDto
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20,MinimumLength =3)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Middle name is required")]
        [StringLength(20, MinimumLength = 3)]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Location Citry is required")]
        [ValidCity]
        public string LocationCity { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [RegularExpression(@"^street \d+, [A-Za-z\s]+, [A-Za-z\s]+$", ErrorMessage = "address must follow format: 'street {street number}, {city}, {country}'")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Date Birth is required")]
        public DateTime DateBirth { get; set; }
        [Required(ErrorMessage = "Telephone is required")]
        [Phone]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Position is required")]
        public PostPositionDto Position { get; set; }
    }
}
