using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Models.ViewModel;
using SnifferManager.Models;

namespace SnifferManager.Controllers
{
    [Error]
    public class DashBoardController : Controller
    {
        private DeviceDbContext context;
        public DashBoardController()
        {
            context = new DeviceDbContext();
        }

        [HttpGet]
        public ActionResult Index()
        {                  
            return View();
        }

        [HttpPost]
        public ActionResult DashBoard(DateTime BeginDate, DateTime EndDate)
        {
            int days = (EndDate - BeginDate).Days + 1;
            List<string> dates = Enumerable.Range(0, days)
                .Select(i => BeginDate.AddDays(i))
                .Select(x => x.ToString("dd.MM.yyy")).ToList();
            EndDate = EndDate.AddDays(1);
            var checks = context.Checks.Where(y => y.CheckDate.HasValue && (y.CheckDate >= BeginDate && y.CheckDate <= EndDate)).ToList();
            var config = context.Configurations.ToList();
            var sales = config.GroupJoin(checks, x => x.SerialNumber, y => (int)y.SerialNumber, (x, y) => new LocationSalesDate
            {
                LocationId = x.SerialNumber,
                LocatioName = x.Description,
                Sales = dates.GroupJoin(y, d => d, e => e.CheckDate.Value.ToString("dd.MM.yyy"), (d, e) => new DashBoardSaleViewModel { Date = d, Total = (int)e.Sum(j => j.Total) }).ToList()
            }).ToList();
            var model = new DashBoardLocationViewModel();
            model.LocationSales = sales;
            model.Dates = dates;
            return PartialView("DashBoard",model);
        }

        [HttpGet]
        public ActionResult Status()
        {
            var model = new StatusFullViewModel();
            var querylog = context.Querylog.GroupBy(x => x.SerialNumber).Select(x => new { id = x.Key, lastdate = x.Max(k => k.ServerTime) });
            var connection = context.Configurations.GroupJoin(querylog, x => x.SerialNumber, y => int.Parse(y.id), (x, y) => new StatusViewModel
            {
                LocationName = x.Description,
                LocationId = x.SerialNumber,
                DurationOfTime = (DateTime.Now - y.FirstOrDefault().lastdate.Value).TotalMilliseconds.ToString()
            }).ToList();
            return View();
        }
    }
}