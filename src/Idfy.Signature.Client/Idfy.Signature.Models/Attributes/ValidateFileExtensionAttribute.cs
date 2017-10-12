using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Idfy.Signature.Models.Attributes
{
    public class ValidateFileNameAttribute : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "The filename extension is invalid";
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                var fileName = value as string;
                var extension = fileName.Split('.').Last()?.ToLowerInvariant();

                switch (extension)
                {
                    case "pdf":
                    case "doc":
                    case "xml":
                    case "txt":
                        return ValidationResult.Success;
                    default:
                        return new ValidationResult(ErrorMessage);
                }

            }
            catch (Exception e)
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}