using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnifferManager.Models.ViewModel
{
    public class ConfigurationViewModel
    {
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public bool WorkMode { get; set; }
        public string KkmTypeString { get; set; }
        public int BaudRate { get; set; }
        public byte Parity { get; set; }
        public byte StopBits { get; set; }
        public byte DataBits { get; set; }
        public string PrinterPort { get; set; }
        public string CashPort { get; set; }
        public string UsbDeviceName { get; set; }
        public string UsbManufacturerName { get; set; }
        public string UsbKey { get; set; }
        public bool? EnableComSniffer { get; set; }
        public bool? EnableUsbSniffer { get; set; }
        public long CashDeskNumber { get; set; }
    }
}