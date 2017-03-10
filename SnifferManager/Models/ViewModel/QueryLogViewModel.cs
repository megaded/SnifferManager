using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnifferManager.Models.ViewModel
{
    public class QueryLogViewModel
    {
        public decimal id { get; set; }
        public string LocatioName { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string QueryType { get; set; }
        public DateTime? ServerTime { get; set; }
        public DateTime? SystemTime { get; set; }
    }
}