using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Reports;
using SnifferManager.Models;

namespace SnifferManager.Controllers
{
    [Error]
    public class ReportController : Controller
    {
        [HttpPost]
        public ActionResult LocationSales(int locationId, DateTime beginDate, DateTime endDate)
        {
            LocationSalesReport report = new LocationSalesReport();
            var model = report.GetReport(locationId, beginDate, endDate);
            return File(model, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "reportLocationSales.xlsx");
        }

    }
}