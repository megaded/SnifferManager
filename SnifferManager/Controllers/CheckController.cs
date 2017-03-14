using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Models.ViewModel;
using PagedList;

namespace SnifferManager.Controllers
{

    public class CheckController : Controller
    {
        DeviceDbContext context;
        public CheckController()
        {
            context = new DeviceDbContext();
        }
        [HttpGet]
        public ActionResult Index(int? page)
        {
            var check = context.Checks.ToList();
            var config = context.Configurations.ToList();
            var model = check.Join(config, x => x.SerialNumber, y => y.SerialNumber, (x, y) => new CheckViewModel
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
                LocationName = y.Description,
                ShopId = x.ShopId,
                ReceiveDate = x.ReceiveDate,
                CheckText = x.CheckText
            }).ToList();
            var pageNumber = page ?? 1;
            var onePageOfCheck = model.ToPagedList(pageNumber, 100);
            ViewBag.Title = "Чеки";
            return View(onePageOfCheck);
        }

        [HttpGet]
        public ActionResult Location(int id)
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

        [HttpGet]
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Location");
            }
            var model = context.Articles.Where(x => x.CheckId == id).ToList().Select(k=>
            new ArticleCheckViewModel
            {
                Name=k.Name,
                Count=k.Count,
                Price=k.Price,
                TotalPrice=k.TotalPrice
            }).ToList();
            ViewBag.Title = $"Чек номер {id}";
            return View(model);
        }

        [HttpGet]
        public ActionResult CheckDate(DateTime checkdate, int id)
        {
            var checks = context.Checks.Where(x => x.SerialNumber == id&& x.CheckDate.HasValue).ToList().Where(x => ((DateTime)x.CheckDate).ToString("dd.MM.yyyy") == checkdate.ToString("dd.MM.yyyy"));
            var model = checks.GroupJoin(context.Articles, x => x.id, y => y.CheckId, (x, y) => new CheckLocationViewModel
            {
                CheckNumber = x.CheckNumber.HasValue ? x.CheckNumber.Value.ToString() : "Нет номера чека",
                Price = x.Total,
                Position = y.Count(),
                CheckText = x.CheckText,
                Articles = y.Select(a => new ArticleCheckViewModel
                {
                    Name = a.Name,
                    Count = a.Count,
                    Price = a.Price,
                    TotalPrice = a.TotalPrice
                }).ToList()
            }).ToList();
            ViewBag.Title = $"{checkdate.ToString("dd.MM.yyyy")} Чеки";
            return View(model);
        }

        [HttpPost]
        public ActionResult Checks(DateTime BeginDate, DateTime EndDate, int LocationId)
        {
            EndDate = EndDate.AddDays(1);
            var check = context.Checks.Where(x => x.SerialNumber == LocationId && x.CheckDate.HasValue && (x.CheckDate >= BeginDate && x.CheckDate <= EndDate)).ToList();
            var article = context.Articles.GroupBy(x => x.CheckId).ToList();
            var model = check.GroupJoin(article, x => x.id, y => y.Key, (x, y) => new CheckLocationViewModel
            {
                CheckId = x.id,
                CheckNumber = x.CheckNumber.ToString(),
                Price = x.Total,
                Position = y.Count(),
                Date = x.CheckDate.HasValue ? x.CheckDate.Value.ToString("dd.MM.yyyy") : ""
            }).ToList();
            ViewBag.Title = "Чеки";
            return PartialView(model);
        }

    }
}