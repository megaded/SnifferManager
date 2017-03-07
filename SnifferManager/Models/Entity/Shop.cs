namespace SnifferManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("shop")]
    public  class Shop
    {
        public decimal id { get; set; }
        public string shop_name { get; set; }
    }
}
