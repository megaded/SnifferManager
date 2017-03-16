using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SnifferManager.Models.ViewModel
{
    public class LocationDetailViewModel
    {
        public string LocationName { get; set; }
        public int LocationId { get; set; }
        public int CheckCount { get; set; }
        public string LastCheckDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BeginDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
    }
}