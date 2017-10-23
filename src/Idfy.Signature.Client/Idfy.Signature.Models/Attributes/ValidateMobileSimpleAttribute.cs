using Idfy.Signature.Models.Misc;
using System.ComponentModel.DataAnnotations;

namespace Idfy.Signature.Models.Attributes
{
    public class ValidateMobileSimpleAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "The mobile number is not valid, remember to include both number and country code";
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var mobile = value as Mobile;

            if(mobile == null || (!string.IsNullOrEmpty(mobile.CountryCode) && !string.IsNullOrEmpty(mobile.Number)))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage);
        }
    }
}