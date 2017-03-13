using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Models.ViewModel;
using PagedList;

namespace SnifferManager.Controllers
{
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
            return View();
        }

        [HttpGet]
        public ActionResult Logs(DateTime BeginDate, DateTime EndDate, int LocatioId)
        {
            return PartialView();
        }
    }
}