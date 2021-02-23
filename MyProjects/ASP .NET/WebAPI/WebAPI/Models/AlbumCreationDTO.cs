using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class AlbumCreationDTO : IValidatableObject
    {
        //public int AlbumID { get; set; } Will be assigned automatically.
        [Required] //Adding for validation otherwise not necessary.
        public string Title { get; set; }
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Title == Description)
            {
                yield return new ValidationResult("Title and Description cannot be the same",
                    new[] { "AlbumCreationDTO" });
            }
        }

        //public Band Band { get; set; }
        //public int BandID { get; set; } Not required because bandID will be passed as argument while creation.
    }
}
