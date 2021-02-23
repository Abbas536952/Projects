using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.ValidationAttributes
{
    //Mainly serves as reusable class level validation.
    public class TestAndDescriptionAttributes : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var albumObject = (AlbumCreationDTO)validationContext.ObjectInstance;
            if(albumObject.Title == albumObject.Description)
            {
                return new ValidationResult("Title and Description cannot be the same.",
                    new[] { "AlbumCreationDTO" });
            }
            return ValidationResult.Success;
        }
    }
}
