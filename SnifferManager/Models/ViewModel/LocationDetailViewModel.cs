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
        public int LocatioId { get; set; }
        public int CheckCount { get; set; }
        public DateTime LastCheckDate { get; set; }
        public List<CheckViewModel> Last10Checks { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BeginDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
    }
}