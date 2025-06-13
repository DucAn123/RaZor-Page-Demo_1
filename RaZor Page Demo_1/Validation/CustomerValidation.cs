using System.ComponentModel.DataAnnotations;

namespace RazorPagesLabA1.Validation
{
    public class CustomerValidation : ValidationAttribute
    {
        public CustomerValidation()
        {
            ErrorMessage = "The year of birth cannot be greater than 2021.";
        }

        public override bool IsValid(object value)
        {
            if (value == null) return false;
            int year = int.Parse(value.ToString());
            return year < 2021;
        }
    }
}
