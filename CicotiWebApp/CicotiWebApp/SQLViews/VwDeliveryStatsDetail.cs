using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicotiWebApp.SQLViews
{
    public class VwDeliveryStatusPivot
    {
        public DateTime InvoiceDate { get; private set; }
        public string ProductType { get; private set; }
        public int Finance{get; private set; }
        public int Warehouse { get; private set; }
        public int Transport { get; private set; }
        public int Pod { get; private set; }
        public int Other { get; private set; }
        public int Total { get; private set; }
        public double UnDelivered { get; private set; }
    }
}
/****** Script for SelectTopNRows command from SSMS  ******/



