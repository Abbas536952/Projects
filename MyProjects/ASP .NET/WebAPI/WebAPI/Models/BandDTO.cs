using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class BandDTO
    {
        //No need of attributes like [Key] here.
        //Only add properties you want to display in output.
        public int ID { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string FoundedYearsAgo { get; set; }
    }
}
