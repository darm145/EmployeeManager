using System.ComponentModel.DataAnnotations;
using AutoMapper;
using EmployeeManager.Core.DTOs;
using EmployeeManager.Core.Mapper;
using EmployeeManager.Core.Models;
using EmployeeManager.Core.Repositories;
using EmployeeManager.Core.Services;
using EmployeeManager.Infrastructure.Data;
using EmployeeManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace EmployeeManager.Test
{
    public class EmployeeTest
    {
        private readonly EmployeeService _employeeService;
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly IMapper _mapper;
        
        public EmployeeTest()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile(new MappingConfiguration());
            });
            _mapper = mapperConfig.CreateMapper();
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_employeeRepositoryMock.Object, _mapper);
        }
        
        [Fact]
        public void Must_Create_Correctly()
        {
            var employee = new Employee
                {
                    FirstName = "David",
                    MiddleName = "Daniel",
                    LastName = "Ramirez",
                    LocationCity = "Bogota",
                    Address = "street 123, bogota, colombia",
                    DateBirth = DateTime.Parse("1998-09-16"),
                    Telephone = "1111111111",
                    Status = "Active",
                    Position =new Position {
                        PositionTitle = "Software Engineer",
                        HireDate = DateTime.Parse("2024-06-02"),
                        Email ="daniel.ramirez@mail.com",
                        Salary = 2000
                        }

                 };
            var validationContext = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults,true);
            Assert.True(isValid);
            Assert.Empty(validationResults);
        }

        [Fact]
        public void FirstName_ShouldBeRequired_WhenNull()
        {
            var employee = new Employee
            {
                FirstName = null,
                MiddleName = "Daniel",
                LastName = "Ramirez",
                LocationCity = "Bogota",
                Address = "street 123, bogota, colombia",
                DateBirth = DateTime.Parse("1998-09-16"),
                Telephone = "1111111111",
                Status = "Active",
                Position =new Position {
                    PositionTitle = "Software Engineer",
                    HireDate = DateTime.Parse("2024-06-02"),
                    Email ="daniel.ramirez@mail.com",
                    Salary = 2000
                    }

            };
            var validationContext = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults,true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("First Name is required", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void FirstName_NeedMinimumCharacters()
        {
            var employee = new Employee
            {
                FirstName = "a",
                MiddleName = "Daniel",
                LastName = "Ramirez",
                LocationCity = "Bogota",
                Address = "street 123, bogota, colombia",
                DateBirth = DateTime.Parse("1998-09-16"),
                Telephone = "1111111111",
                Status = "Active",
                Position = new Position
                {
                    PositionTitle = "Software Engineer",
                    HireDate = DateTime.Parse("2024-06-02"),
                    Email = "daniel.ramirez@mail.com",
                    Salary = 2000
                }

            };
            var validationContext = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults,true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("First name need at least 3 characters and no more than 20", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void MiddleName_ShouldBeRequired_WhenNull()
        {
            var employee = new Employee
            {
                FirstName = "David",
                MiddleName = null,
                LastName = "Ramirez",
                LocationCity = "Bogota",
                Address = "street 123, bogota, colombia",
                DateBirth = DateTime.Parse("1998-09-16"),
                Telephone = "1111111111",
                Status = "Active",
                Position = new Position
                {
                    PositionTitle = "Software Engineer",
                    HireDate = DateTime.Parse("2024-06-02"),
                    Email = "daniel.ramirez@mail.com",
                    Salary = 2000
                }

            };
            var validationContext = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults, true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("Middle Name is required", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void MiddleName_NeedMinimumCharacters()
        {
            var employee = new Employee
            {
                FirstName = "David",
                MiddleName = "a",
                LastName = "Ramirez",
                LocationCity = "Bogota",
                Address = "street 123, bogota, colombia",
                DateBirth = DateTime.Parse("1998-09-16"),
                Telephone = "1111111111",
                Status = "Active",
                Position = new Position
                {
                    PositionTitle = "Software Engineer",
                    HireDate = DateTime.Parse("2024-06-02"),
                    Email = "daniel.ramirez@mail.com",
                    Salary = 2000
                }

            };
            var validationContext = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults, true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("Middle name need at least 3 characters and no more than 20", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void LastName_ShouldBeRequired_WhenNull()
        {
            var employee = new Employee
            {
                FirstName = "David",
                MiddleName = "Daniel",
                LastName = null,
                LocationCity = "Bogota",
                Address = "street 123, bogota, colombia",
                DateBirth = DateTime.Parse("1998-09-16"),
                Telephone = "1111111111",
                Status = "Active",
                Position = new Position
                {
                    PositionTitle = "Software Engineer",
                    HireDate = DateTime.Parse("2024-06-02"),
                    Email = "daniel.ramirez@mail.com",
                    Salary = 2000
                }

            };
            var validationContext = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults, true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("Last Name is required", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void LastName_NeedMinimumCharacters()
        {
            var employee = new Employee
            {
                FirstName = "David",
                MiddleName = "Daniel",
                LastName = "a",
                LocationCity = "Bogota",
                Address = "street 123, bogota, colombia",
                DateBirth = DateTime.Parse("1998-09-16"),
                Telephone = "1111111111",
                Status = "Active",
                Position = new Position
                {
                    PositionTitle = "Software Engineer",
                    HireDate = DateTime.Parse("2024-06-02"),
                    Email = "daniel.ramirez@mail.com",
                    Salary = 2000
                }

            };
            var validationContext = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults, true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("Last name need at least 3 characters and no more than 20", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void LocationCity_MustBe_ValidCity()
        {
            var employee = new Employee
            {
                FirstName = "David",
                MiddleName = "Daniel",
                LastName = "Ramirez",
                LocationCity = "asdasd",
                Address = "street 123, bogota, colombia",
                DateBirth = DateTime.Parse("1998-09-16"),
                Telephone = "1111111111",
                Status = "Active",
                Position = new Position
                {
                    PositionTitle = "Software Engineer",
                    HireDate = DateTime.Parse("2024-06-02"),
                    Email = "daniel.ramirez@mail.com",
                    Salary = 2000
                }

            };
            var validationContext = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults, true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("The field LocationCity is invalid.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void Telephone_ShouldBeRequired_WhenNull()
        {
            var employee = new Employee
            {
                FirstName = "David",
                MiddleName = "Daniel",
                LastName = "Ramirez",
                LocationCity = "Bogota",
                Address = "street 123, bogota, colombia",
                DateBirth = DateTime.Parse("1998-09-16"),
                Telephone = null,
                Status = "Active",
                Position = new Position
                {
                    PositionTitle = "Software Engineer",
                    HireDate = DateTime.Parse("2024-06-02"),
                    Email = "daniel.ramirez@mail.com",
                    Salary = 2000
                }

            };
            var validationContext = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults, true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("Telephone is required", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void Telephone_ShouldBe_ValidNumber()
        {
            var employee = new Employee
            {
                FirstName = "David",
                MiddleName = "Daniel",
                LastName = "Ramirez",
                LocationCity = "Bogota",
                Address = "street 123, bogota, colombia",
                DateBirth = DateTime.Parse("1998-09-16"),
                Telephone = "1111a11111",
                Status = "Active",
                Position = new Position
                {
                    PositionTitle = "Software Engineer",
                    HireDate = DateTime.Parse("2024-06-02"),
                    Email = "daniel.ramirez@mail.com",
                    Salary = 2000
                }

            };
            var validationContext = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults, true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("The Telephone field is not a valid phone number.", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void Status_ShouldBeRequired_WhenNull()
        {
            var employee = new Employee
            {
                FirstName = "David",
                MiddleName = "Daniel",
                LastName = "Ramirez",
                LocationCity = "Bogota",
                Address = "street 123, bogota, colombia",
                DateBirth = DateTime.Parse("1998-09-16"),
                Telephone = "1111111111",
                Status = null,
                Position = new Position
                {
                    PositionTitle = "Software Engineer",
                    HireDate = DateTime.Parse("2024-06-02"),
                    Email = "daniel.ramirez@mail.com",
                    Salary = 2000
                }

            };
            var validationContext = new ValidationContext(employee);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(employee, validationContext, validationResults, true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("Status is required", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void PositionTitle_ShouldBeRequired_WhenNull()
        {
            var position = new Position
            {
                PositionTitle = null,
                HireDate = DateTime.Parse("2024-06-02"),
                Email = "daniel.ramirez@mail.com",
                Salary = 2000
            };

            var validationContext = new ValidationContext(position);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(position, validationContext, validationResults, true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("Position Title is required", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void Email_ShouldBeRequired_WhenNull()
        {
            var position = new Position
            {
                PositionTitle = "Software Engineer",
                HireDate = DateTime.Parse("2024-06-02"),
                Email = null,
                Salary = 2000
            };
            var validationContext = new ValidationContext(position);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(position, validationContext, validationResults, true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("Email is required", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void Email_ShouldBeValidMail()
        {
            var position = new Position
            {
                PositionTitle = "Software Engineer",
                HireDate = DateTime.Parse("2024-06-02"),
                Email = "daniel.ramirezmail.com",
                Salary = 2000
            };
            var validationContext = new ValidationContext(position);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(position, validationContext, validationResults, true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("Must use a valid email address", validationResults[0].ErrorMessage);
        }

        [Fact]
        public void Salary_ShouldBePositive()
        {
            var position = new Position
            {
                PositionTitle = "Software Engineer",
                HireDate = DateTime.Parse("2024-06-02"),
                Email = "daniel.ramirez@mail.com",
                Salary = -2000
            };
            var validationContext = new ValidationContext(position);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(position, validationContext, validationResults, true);
            Assert.False(isValid);
            Assert.Single(validationResults);
            Assert.Equal("Salary can´t be less than 0", validationResults[0].ErrorMessage);
        }

        [Fact]
        public async void GetEmployee_ShouldReturnEmployeeDto()
        {
            var employee = new Employee
            {
                Id = 1,
                FirstName = "David",
                MiddleName = "Daniel",
                LastName = "Ramirez",
                LocationCity = "Bogota",
                Address = "street 123, bogota, colombia",
                DateBirth = DateTime.Parse("1998-09-16"),
                Telephone = "1111111111",
                Status = "Active",
                Position = new Position
                {
                    Id = 1,
                    EmployeeId = 1,
                    PositionTitle = "Software Engineer",
                    HireDate = DateTime.Parse("2024-06-02"),
                    Email = "daniel.ramirez@mail.com",
                    Salary = 2000
                }

            };

            _employeeRepositoryMock.Setup(repo => repo.GetById(1)).ReturnsAsync(employee);
            var result = await _employeeService.GetById(1);
            Assert.NotNull(result);
            Assert.Equal(result.Id, employee.Id);
            Assert.Equal(result.FirstName, employee.FirstName);
            Assert.Equal(result.MiddleName, employee.MiddleName);
            Assert.Equal(result.LastName, employee.LastName);
            Assert.Equal(result.LocationCity, employee.LocationCity);
            Assert.Equal(result.Address, employee.Address);
            Assert.Equal(result.DateBirth, employee.DateBirth);
            Assert.Equal(result.Telephone, employee.Telephone);
            Assert.Equal(result.Status, employee.Status);
            Assert.Equal(result.Position.PositionTitle, employee.Position.PositionTitle);
            Assert.Equal(result.Position.HireDate, employee.Position.HireDate);
            Assert.Equal(result.Position.Email, employee.Position.Email);
            Assert.Equal(result.Position.Salary, employee.Position.Salary);
            _employeeRepositoryMock.Verify(repo => repo.GetById(1), Times.Once);
        }

        [Fact]
        public async void CreateEmployee_ShouldSaveCorrectly()
        {
            var employeeDto = new PostEmployeeDto
            {
                FirstName = "David",
                MiddleName = "Daniel",
                LastName = "Ramirez",
                LocationCity = "Bogota",
                Address = "street 123, bogota, colombia",
                DateBirth = DateTime.Parse("1998-09-16"),
                Telephone = "1111111111",
                Status = "Active",
                Position = new PostPositionDto
                {
                    PositionTitle = "Software Engineer",
                    HireDate = DateTime.Parse("2024-06-02"),
                    Email = "daniel.ramirez@mail.com",
                    Salary = 2000
                }

            };

            await _employeeService.Save(employeeDto);
            var employee = _mapper.Map<Employee>(employeeDto);
            _employeeRepositoryMock.Verify(r =>
                r.Save(It.Is<Employee>(e => e.FirstName == employee.FirstName &&
                e.LastName == employee.LastName &&
                e.MiddleName == employee.MiddleName &&
                e.LocationCity == employee.LocationCity &&
                e.Address == employee.Address &&
                e.DateBirth == employee.DateBirth &&
                e.Telephone == employee.Telephone &&
                e.Status == employee.Status &&
                e.Position.PositionTitle == employee.Position.PositionTitle &&
                e.Position.HireDate == employee.Position.HireDate &&
                e.Position.Email == employee.Position.Email &&
                e.Position.Salary == employee.Position.Salary)), Times.Once);
        }

        [Fact]
        public async Task GetAllEmployees_ShouldReturnListOfEmployeeDto()
        {
            var getAllEmployeesDtos = new List<GetAllEmployeesDto>
            {
                new GetAllEmployeesDto
                {
                    EmployeeId =1,
                    FirstName="David",
                    LastName="Ramiez",
                    DateArrival=DateTime.Parse("2024-06-02"),
                    PositionTitle ="Software Engineer",
                    Status ="Active"
                },
                new GetAllEmployeesDto
                {
                    EmployeeId =2,
                    FirstName="Daniel",
                    LastName="Moreno",
                    DateArrival=DateTime.Parse("2023-06-02"),
                    PositionTitle ="Software Engineer",
                    Status ="InActive"
                }
            };

            _employeeRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(getAllEmployeesDtos);

            var result = await _employeeService.GetAll();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());

        }
    }
}