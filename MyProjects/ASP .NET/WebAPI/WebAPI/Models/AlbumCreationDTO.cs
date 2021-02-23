using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ValidationAttributes;

namespace WebAPI.Models
{
    //[TestAndDescriptionAttributes]
    public class AlbumCreationDTO : IValidatableObject
    {
        //public int AlbumID { get; set; } Will be assigned automatically.
        [Required(ErrorMessage = "Values cannot be null")] //Adding for validation otherwise not necessary.
        //ErrorMessage attribute can be added to any data annotation to display custom error message.
        public string Title { get; set; }
        public string Description { get; set; }

        //The function Validate is present in the interface IValidatableObject and implementing it
        //will allow us to add validations for different attributes.
        //Because it cannot be reused for diff. attributes, we use class level validation instead.
        //Note:Class level validation will cause trouble when creating collection of albums, so use this.
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title == Description)
            {
                yield return new ValidationResult("Title and Description cannot be the same",
                    new[] { "AlbumCreationDTO" });
            }
        }

        //public Band Band { get; set; }
        //public int BandID { get; set; } Not required because bandID will be passed as argument while creation.
    }
}
