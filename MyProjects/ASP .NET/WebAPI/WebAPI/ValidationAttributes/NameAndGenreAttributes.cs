using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ValidationAttributes
{
    public class NameAndGenreAttributes : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var bandObject = (BandCreationDTO)validationContext.ObjectInstance;
            if (bandObject.Name == bandObject.Genre)
            {
                return new ValidationResult("Name and Genre cannot be the same.",
                    new[] { "BandCreationDTO" });
            }
            return ValidationResult.Success;
        }
    }
}
