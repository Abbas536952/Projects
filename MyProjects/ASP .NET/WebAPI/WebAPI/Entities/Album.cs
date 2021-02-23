using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Entities
{
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [ForeignKey("BandID")]
        public Band Band { get; set; }
        public int BandID { get; set; }
    }
}
