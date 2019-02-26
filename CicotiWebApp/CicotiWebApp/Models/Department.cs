﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; }
    }
}
