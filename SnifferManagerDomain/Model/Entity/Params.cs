namespace SnifferManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("params")]
    public  class Params
    {
        public decimal id { get; set; }
        public byte[] command_body { get; set; }
        public string serial_number { get; set; }
        public System.DateTime receive_date { get; set; }
        public string packet_number { get; set; }
        public string packet_size { get; set; }
        public string cmd { get; set; }
        public string cmd_request { get; set; }
        public string crc16 { get; set; }
        public bool parsed { get; set; }
        public DateTime? server_time { get; set; }
        public DateTime? system_time { get; set; }
    }
}
