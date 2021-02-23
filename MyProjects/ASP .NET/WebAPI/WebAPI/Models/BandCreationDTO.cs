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
        //public int ID { get; set; } Key will be assigned by database itself.
        
        [Required]
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime Founded { get; set; }
        
        
        //Adding this so that user can provide albums aswell when creating a band.
        public ICollection<AlbumCreationDTO> Albums { get; set; } = new List<AlbumCreationDTO>();

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
