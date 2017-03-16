namespace SnifferManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("configuration")]
    public  class Configuration
    {
        public bool WorkMode { get; set; }
        public string KkmTypeString { get; set; }
        public int BaudRate { get; set; }
        public byte Parity { get; set; }
        public byte StopBits { get; set; }
        public byte DataBits { get; set; }
        public string PrinterPort { get; set; }
        public string CashPort { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SerialNumber { get; set; }
        public string Description { get; set; }
        public string UsbDeviceName { get; set; }
        public string UsbManufacturerName { get; set; }
        public string UsbKey { get; set; }
        public bool? EnableComSniffer { get; set; }
        public bool? EnableUsbSniffer { get; set; }
        public long CashDeskNumber { get; set; }

        public Configuration()
        {
            KkmTypeString = "ККМ";
            BaudRate = 19200;
            PrinterPort = "COM1";
            CashPort = "COM3";
        }
    }
}