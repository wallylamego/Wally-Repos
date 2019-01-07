using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class LoadLine
    {
        public int LoadLineID { get; set; }
        public int LoadID { get; set; }
        public Invoice Invoice { get; set; }
    }
}
