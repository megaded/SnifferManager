namespace SnifferManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("querylog")]
    public  class Querylog
    {
        public decimal id { get; set; }
        public string SerialNumber { get; set; }
        public System.DateTime ReceiveDate { get; set; }
        public string QueryType { get; set; }
        public DateTime? ServerTime { get; set; }
        public DateTime? SystemTime { get; set; }
    }
}
