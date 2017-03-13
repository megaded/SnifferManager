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
                Change=x.Change,
                CheckDate=x.CheckDate,
                DocNumber=x.DocNumber,
                DocType=x.DocType,
                Payment=x.Payment,
                Total=x.Total,
                CheckNumber=x.CheckNumber,
                id=x.id,
                SerialNumber=x.SerialNumber,
                LocationName=y.Description,
                ShopId=x.ShopId,
                ReceiveDate=x.ReceiveDate,
                CheckText=x.CheckText
            }).ToList();
            var pageNumber = page ?? 1;
            var onePageOfCheck = model.ToPagedList(pageNumber, 100);
            return View(onePageOfCheck);
        }

        [HttpGet]
        public ActionResult Location(int id)
        {
            var article = context.Articles.GroupBy(x => x.CheckId).ToList();
            var check = context.Checks.Where(x => x.SerialNumber == id).ToList();
            var model = check.Join(article, x => x.id, y => y.Key, (x, y) => new CheckLocationViewModel
            { CheckNumber = (int)x.CheckNumber,
                Price = (float)y.Sum(z => z.TotalPrice),
                Position = y.Count(),
                Date =((DateTime) x.CheckDate).ToString("dd.mm.yyyy")
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var model = context.Articles.Where(x => x.CheckId == id).ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult CheckDate(DateTime checkdate, int id)
        {
            var checks = context.Checks.Where(x => x.SerialNumber == id).ToList().Where(x => ((DateTime) x.CheckDate).ToString("dd.MM.yyyy")==checkdate.ToString("dd.MM.yyyy"));
            var model = checks.GroupJoin(context.Articles, x => x.id, y => y.CheckId, (x, y) => new CheckLocationViewModel
            {
                CheckNumber = (int)x.CheckNumber,
                Price = (float)y.Sum(z => z.Price),
                Position = y.Count(),
            }).ToList();
            return View(model);
        }

    }
}