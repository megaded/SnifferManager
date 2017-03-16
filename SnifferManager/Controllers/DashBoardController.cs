using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Models.ViewModel;

namespace SnifferManager.Controllers
{
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
            var BeginDate = new DateTime(2017, 1, 1);
            var EndDate = new DateTime(2017, 1, 3);
            int days = (EndDate - BeginDate).Days + 1;
            List<string> dates = Enumerable.Range(0, days)
                .Select(i => BeginDate.AddDays(i))
                .Select(x => x.ToString("dd.MM.yyy")).ToList();
            var sales = context.Checks.Where(y => y.CheckDate.HasValue && (y.CheckDate >= BeginDate && y.CheckDate <= EndDate)).ToList();
            var locationSales = sales.GroupBy(x => new { location = x.SerialNumber, checkdate = x.CheckDate.Value.ToString("dd.MM.yyyy") });
         /*   var datetoCheckDate = dates.GroupJoin(locationSales, x => x, y => y.Key.checkdate, (x, y) =>
              new LocationSalesDate
              {
                  LocationId =(int) y.FirstOrDefault().Key.location,
                  Sales=y.SelectMany(x=>x.Sum())
            }); */
            var model = new DashBoardLocationViewModel();
            model.Dates = dates;

            return View(model);
        }
    }
}