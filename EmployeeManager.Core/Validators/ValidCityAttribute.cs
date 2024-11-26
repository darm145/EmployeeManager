using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.Core.Validators
{
    public class ValidCityAttribute : ValidationAttribute
    {
        private readonly string[] _validCities = new[] { "Bogota", "Medellin", "Cali", "Barranquilla"};

        public ValidCityAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var city = value.ToString();

            return _validCities.Contains(city, StringComparer.OrdinalIgnoreCase);
        }
    }
}
