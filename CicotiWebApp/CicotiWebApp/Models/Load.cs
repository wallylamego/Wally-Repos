using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Load
    {
        public int LoadID { get; set; }
        public string LoadName { get; set; }
        public string LoadDate { get; set; }
        public Vehicle Vehicle { get; set; }
          
        public List<Invoice> Invoices { get; set; }
    }
}
