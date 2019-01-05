using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class CustomerAccount
    {
        int CustomerAccountID { get; set;}
        string AccountNumber { get; set; }
        string AccountDescription { get; set; }
        string Terms { get; set; }
    }
}
