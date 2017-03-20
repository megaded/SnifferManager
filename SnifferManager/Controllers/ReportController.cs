using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Reports;

namespace SnifferManager.Controllers
{
    public class ReportController : Controller
    {
       [HttpPost]
        public ActionResult LocationSales()
        {
            return View();
        }
       
    }
}