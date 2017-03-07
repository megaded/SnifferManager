using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Models.ViewModel;

namespace SnifferManager.Controllers
{
    [RoutePrefix("check")]
    public class CheckController : Controller
    {
        DeviceDbContext context;
        public CheckController()
        {
            context = new DeviceDbContext();
        }
        [HttpGet]       
        public ActionResult Index()
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
            return View(model);
        }
    }
}