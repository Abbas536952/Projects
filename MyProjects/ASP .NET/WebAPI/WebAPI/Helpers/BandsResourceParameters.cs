using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Helpers
{
    public class BandsResourceParameters
    {
        //This class contains the search and filter queries/parameters.
        public string Genre { get; set; }
        public string Search { get; set; }
        //Can have other data members aswell that are passed using query and can be grouped.
        //This is mainly implemented to ensure flexibility and reusability.
    }
}
