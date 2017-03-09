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
    }
}