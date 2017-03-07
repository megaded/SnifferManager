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
        public System.DateTime ReceiveDate { get; set; }
        public string LogType { get; set; }
        public string Message { get; set; }
        public Nullable<System.DateTime> ServerTime { get; set; }
        public Nullable<System.DateTime> SystemTime { get; set; }
    }
}