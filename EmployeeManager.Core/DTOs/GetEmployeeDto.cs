using EmployeeManager.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Core.DTOs
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string LocationCity { get; set; }
        public string Address { get; set; }
        public DateTime DateBirth { get; set; }
        [Phone]
        public string Telephone { get; set; }
        public string Status { get; set; }
        public GetPositionDto Position { get; set; }
    }
}
