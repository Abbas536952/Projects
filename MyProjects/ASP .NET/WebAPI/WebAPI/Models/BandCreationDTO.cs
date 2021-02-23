using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class BandCreationDTO
    {
        //public int ID { get; set; } Key will be assigned by database itself.
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime Founded { get; set; }
        //Adding this so that user can provide albums aswell when creating a band.
        public ICollection<AlbumCreationDTO> Albums { get; set; } = new List<AlbumCreationDTO>();
    }
}
