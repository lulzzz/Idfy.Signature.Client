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
                var extension = System.IO.Path.GetExtension(fileName);
                if (extension != null)
                {
                    switch (extension.ToLowerInvariant())
                    {
                        case ".pdf":
                        case ".doc":
                        case ".docx":
                        case ".rtf":
                        case ".xml":
                        case ".txt":
                        case ".odt":
                        case ".ott":
                            return ValidationResult.Success;
                        default:
                            return new ValidationResult(ErrorMessage);
                    }
                }
                return new ValidationResult(ErrorMessage);
            }
            catch (Exception e)
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }
}