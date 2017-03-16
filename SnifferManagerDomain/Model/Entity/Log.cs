namespace SnifferManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("logs")]
    public  class Log
    {
        public decimal id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string LogType { get; set; }
        public string Message { get; set; }
        public DateTime? ServerTime { get; set; }
        public DateTime? SystemTime { get; set; }
    }
}