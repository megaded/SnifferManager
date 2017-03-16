namespace SnifferManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("checks")]
    public  class Check
    {
        public float? Change { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? DocNumber { get; set; }
        public int? DocType { get; set; }
        public float? Payment { get; set; }
        public float? Total { get; set; }
        public int? CheckNumber { get; set; }
        public decimal id { get; set; }
        public long? SerialNumber { get; set; }
        public int? ShopId { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string CheckText { get; set; }
    }
}