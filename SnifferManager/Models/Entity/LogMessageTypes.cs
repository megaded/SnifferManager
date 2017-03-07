namespace SnifferManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("logmessagetypes")]
    public  class Logmessagetypes
    {
        public int id { get; set; }
        public string Description { get; set; }
    }
}