using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SnifferManager.Models
{
    public static class ByteArrayToString
    {
        public static string ByteToString(this byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}