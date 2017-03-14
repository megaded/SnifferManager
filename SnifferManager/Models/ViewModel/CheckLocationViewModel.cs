using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnifferManager.Models.ViewModel
{
    public class CheckLocationViewModel
    {
        public decimal CheckId { get; set; }
        public string CheckNumber { get; set; }
        public float? Price { get; set; }
        public int Position { get; set; }
        public string Date { get; set; }
        public string CheckText { get; set; }
        public List<ArticleCheckViewModel> Articles { get; set; }
        public CheckLocationViewModel()
        {
            Articles = new List<ArticleCheckViewModel>();
        }   
    }

}