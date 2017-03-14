using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Models.ViewModel;


namespace SnifferManager.Controllers
{
    public class LocationController : Controller
    {
        DeviceDbContext context;
        public LocationController()
        {
            context = new DeviceDbContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var config = context.Configurations.ToList();
            var checks = context.Checks.GroupBy(x => x.SerialNumber).Select(x => new { id = x.Key, count = x.Count(), lastdate = x.Max(z => z.CheckDate) }).ToList();
            var model = config.GroupJoin(checks, x => x.SerialNumber, y => y.id, (x, y) => y.Select(k => new LocationDetailViewModel
            {
                LocationId = x.SerialNumber,
                LocationName = x.Description ?? "Название не указано",
                CheckCount = k.count,
                LastCheckDate =((DateTime) k.lastdate).ToString("dd.MM.yyyy")
            }).DefaultIfEmpty(new LocationDetailViewModel
            {
                LocationId =x.SerialNumber,
                LocationName = x.Description??"Название не указано",
                CheckCount=0,
                LastCheckDate=""

            })).SelectMany(g=>g).ToList();
            ViewBag.Title = "Арендаторы";
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var entity = context.Configurations.Find(id);
            if (entity == null)
            {
                return HttpNotFound("Указаный ID не существует.");
            }
            var model = new LocationDetailViewModel();
            model.LocationId = entity.SerialNumber;
            model.LocationName = entity.Description;
            ViewBag.Title = entity.Description;
            return View(model);
        }

        [HttpPost]
        public ActionResult Sales(DateTime BeginDate, DateTime EndDate,int LocationId)
        {
            EndDate = EndDate.AddDays(1);
            var sale = context.Checks.ToList().Where(y => y.SerialNumber == LocationId && y.CheckDate.HasValue && (y.CheckDate>= BeginDate && y.CheckDate<=EndDate)).GroupBy(x => x.CheckDate.Value.ToString("dd.MM.yyyy"));
            var model = new SalesViewModel();
            model.LocationId = LocationId;
             model.Sales = sale.Select(x => new SalesDateViewModel()
            {
                Date = DateTime.Parse( x.Key),
                Total = (float)x.Sum(m => m.Total),
                CountCheck = x.Count()
            }).ToList();
            model.TotalPrice = model.Sales.Sum(x => x.Total);
            model.TotalCheck = model.Sales.Sum(x => x.CountCheck);
            return PartialView(model);
        }
    }
}