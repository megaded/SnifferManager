using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnifferManager.Models.ViewModel
{
    public class LocationSalesDate
    {
        public int LocationId { get; set; }
        public List<DashBoardSaleViewModel> Sales { get; set; }       
        public LocationSalesDate()
        {
            Sales = new List<DashBoardSaleViewModel>();
        }
    }
}