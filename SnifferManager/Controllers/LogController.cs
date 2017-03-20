using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Models.ViewModel;
using SnifferManager.Models;
using PagedList;

namespace SnifferManager.Controllers
{
    [Error]
    public class LogController : Controller
    {
        DeviceDbContext context;

        public LogController()
        {
            context = new DeviceDbContext();
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            var log = context.Logs.ToList();
            var config = context.Configurations.ToList();
            var model = log.Join(config, x => x.SerialNumber, y => y.SerialNumber.ToString(), (x, y) => new LogViewModel
            {
                id=x.id,
                LocatioName=y.Description,
                SerialNumber=x.SerialNumber,
                ReceiveDate=x.ReceiveDate,
                LogType=x.LogType,
                Message=x.Message,
                ServerTime=x.ServerTime,
                SystemTime=x.SystemTime
            });
            var pageNumber = page ?? 1;
            var onePageOfLog = model.ToPagedList(pageNumber, 100);
            return View(onePageOfLog);
        }

        [HttpGet]
        public ActionResult Location(int id)
        {
            var entity = context.Configurations.Find(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            var model = new LocationDetailViewModel();
            model.LocationId = entity.SerialNumber;
            model.LocationName = entity.Description;
            return View(model);
        }

        [HttpPost]
        public ActionResult Logs(DateTime BeginDate, DateTime EndDate, int LocationId)
        {
            var id = LocationId.ToString();
            var model = context.Logs.Where(x => x.SerialNumber == id&&x.ServerTime.HasValue &&(x.ServerTime>=BeginDate&&x.ServerTime<=EndDate)).
                Select(y=>new LogViewModel
                {
                    id=y.id,
                    ReceiveDate=y.ReceiveDate,
                    LogType=y.LogType,
                    Message=y.Message,
                    SystemTime=y.SystemTime,
                    ServerTime=y.ServerTime
                }).ToList();
            return PartialView(model);
        }
    }
}