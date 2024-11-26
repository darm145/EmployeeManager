using System.ComponentModel.DataAnnotations;
using EmployeeManager.Core.Validators;

namespace EmployeeManager.Core.DTOs
{
    public class UpdateEmployeeDto
    {
        [Required]
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public string MiddleName { get; set; }
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }
        [ValidCity]
        public string LocationCity { get; set; }
        [RegularExpression(@"^street \d+, [A-Za-z\s]+, [A-Za-z\s]+$", ErrorMessage = "address must follow format: 'street {street number}, {city}, {country}'")]
        public string Address { get; set; }
        [Phone]
        public string Telephone { get; set; }
        public string Status { get; set; }
        public UpdatePositionDto Position { get; set; }
    }
}
