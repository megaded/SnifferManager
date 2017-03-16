using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SnifferManager.Models
{
    public  class KKMCode
    {
        public enum KKM
        {
            [Description("Штрих-М")]
            ShtrihM = 0,
            [Description("Сервис-Плюс")]
            ServisPlus = 1,
            [Description("Атол")]
            Atol = 2,
            [Description("Спарк")]
            Spark = 3,
            [Description("Прим")]
            Prim = 4,
            [Description("Мебиус")]
            Mebius = 5,
            [Description("Меркурий")]
            Merkurii = 6,
            [Description("PosPrint")]
            PosPrint = 7,
            [Description("Порт")]
            Port = 8,
            [Description("Пирит")]
            Pirit = 9,
            [Description("Орион")]
            Orion = 10
        }
       
    }
}