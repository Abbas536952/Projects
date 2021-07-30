using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class Band
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Genre { get; set; }
        public DateTime Founded { get; set; }


        public List<Album> Albums = new List<Album>(); //Initializing here to avoid Null Exception.
    }
}
