using Microsoft.Extensions.Primitives;

namespace EmployeeManager.Core.DTOs
{
    public class GetAllEmployeesDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public String PositionTitle { get; set; } 
        public DateTime DateArrival { get; set; }
        public string Status { get; set; }
    }
}
