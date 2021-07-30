using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class BandUpdateDTO
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime Founded { get; set; }
        public List<AlbumUpdateDTO> Albums = new List<AlbumUpdateDTO>();
    }
}
