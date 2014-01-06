using System;
using System.Globalization;
using System.Windows.Controls;

namespace AgeValidator
{
    public class AgeValidationRule : ValidationRule
    {
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public string ErrorMessage { get; set; }

        public AgeValidationRule()
        {
            this.MinimumAge = 1;
            this.MaximumAge = 100;
            this.ErrorMessage = "Wrong age";
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var result = new ValidationResult(true, null);
            int ageValue = (int)float.Parse(value.ToString());
            if (ageValue < this.MinimumAge ||
                   (this.MaximumAge > 0 &&
                    ageValue > this.MaximumAge))
            {
                result = new ValidationResult(false, this.ErrorMessage);
            }
            return result;
        }
    }
}
