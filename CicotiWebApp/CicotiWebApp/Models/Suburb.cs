using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Suburb
    {
        public int SuburbID { get; set; }
        public string SuburbName { get; set;}
        public int CityID { get; set;}

        public City City { get; set; }
    }
}
