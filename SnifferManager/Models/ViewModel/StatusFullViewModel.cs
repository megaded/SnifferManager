using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnifferManager.Models.ViewModel
{
    public class StatusFullViewModel
    {
        public List<StatusViewModel> Noconnection { get; set; }
        public List<StatusViewModel> NoData { get; set; }
        public List<StatusViewModel> NoCheck { get; set; }
    }
}