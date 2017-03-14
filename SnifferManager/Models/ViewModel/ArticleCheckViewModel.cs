using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnifferManager.Models.ViewModel
{
    public class ArticleCheckViewModel
    {
        public string Name { get; set; }
        public float? Count { get; set; }       
        public float? Price { get; set; }
        public float? TotalPrice { get; set; }       
    }
}