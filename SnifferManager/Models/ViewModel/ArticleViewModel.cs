using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnifferManager.Models.ViewModel
{
    public class ArticleViewModel
    {
        public string ArtNumber { get; set; }
        public float? Count { get; set; }
        public string Group { get; set; }
        public string Name { get; set; }
        public float? Price { get; set; }
        public float? TotalPrice { get; set; }
        public long CheckId { get; set; }
        public decimal id { get; set; }
    }
}