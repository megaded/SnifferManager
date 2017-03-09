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
            var config = context.Configurations.Select(x => new ConfigurationViewModel
            {
                Name = x.Description,
                SerialNumber = x.SerialNumber
            }).ToList();
            return View(config);
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
            model.LocatioId = entity.SerialNumber;
            model.LocationName = entity.Description;
            model.CheckCount = context.Checks.Where(x => x.SerialNumber == id).Count();
            model.LastCheckDate = (DateTime)context.Checks.Max(x => x.CheckDate);
            model.Last10Checks = context.Checks.OrderByDescending(x => x.CheckDate).Take(10).Select(x => new CheckViewModel
            {
                Change = x.Change,
                CheckDate = x.CheckDate,
                DocNumber = x.DocNumber,
                DocType = x.DocType,
                Payment = x.Payment,
                Total = x.Total,
                CheckNumber = x.CheckNumber,
                id = x.id,
                SerialNumber = x.SerialNumber,
                ShopId = x.ShopId,
                ReceiveDate = x.ReceiveDate,
                CheckText = x.CheckText
            }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Sales(DateTime BeginDate, DateTime EndDate,int LocatioId)
        {
            var sale = context.Checks.ToList().Where(y => y.SerialNumber == LocatioId && y.CheckDate.HasValue && (y.CheckDate>= BeginDate && y.CheckDate<=EndDate)).GroupBy(x => x.CheckDate.Value.ToString("dd.MM.yyyy"));
            var model = sale.Select(x => new SalesViewModel()
            {
                Date = x.Key,
                Total = (float)x.Sum(m => m.Total),
                CountCheck = x.Count()
            }).ToList();
            return PartialView(model);
        }
    }
}