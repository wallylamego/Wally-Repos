using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class CustomerAccount
    {
        public int CustomerAccountID { get; set;}
        public string AccountNumber { get; set; }
        public string AccountDescription { get; set; }
        public string Terms { get; set; }
    }
}
