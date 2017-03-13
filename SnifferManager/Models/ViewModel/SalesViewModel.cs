using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnifferManager.Models.ViewModel
{
    public class SalesViewModel
    {
        public int LocationId { get; set; }
        public List<SalesDateViewModel> Sales { get; set; }
        public float TotalPrice { get; set; }
        public int TotalCheck { get; set; }
        public SalesViewModel()
        {
            Sales = new List<SalesDateViewModel>();
        }
     
    }
}