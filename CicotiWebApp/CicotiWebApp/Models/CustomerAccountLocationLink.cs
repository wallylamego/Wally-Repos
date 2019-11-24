using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class CustomerAccountLocationLink
    {
        public int CustomerAccountLocationLinkID { get; set; }
        public int CustomerAccountID { get; set; }
        public int ? LocationID { get; set; }
        public bool DefaultLocation{ get; set; }

        public Location Location { get; set; }
        public CustomerAccount CustomerAccount { get; set; }
    }
}
