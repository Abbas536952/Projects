using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ValidationAttributes;

namespace WebAPI.Models
{
    //[NameAndGenreAttributes]
    public class BandCreationDTO : IValidatableObject
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime Founded { get; set; }
        public List<AlbumCreationDTO> Albums = new List<AlbumCreationDTO>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Name == Genre)
            {
                yield return new ValidationResult("Name and Genre cannot be the same.",
                    new[] { "BandCreationDTO" });
            }
        }
    }
}
