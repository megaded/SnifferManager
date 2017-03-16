using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnifferManager.Models.ViewModel
{
    public class DashBoardLocationViewModel
    {
        public List<string> Dates { get; set; }
        public List<LocationSalesDate> LocationSales { get; set; }
    }
}