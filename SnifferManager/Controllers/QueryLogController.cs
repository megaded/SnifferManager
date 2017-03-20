using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SnifferManager.Models.ViewModel;
using SnifferManager.Models;

namespace SnifferManager.Controllers
{
    [Error]
    public class QueryLogController : Controller
    {
        DeviceDbContext context;
        public QueryLogController()
        {
            context = new DeviceDbContext();
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            var querylog = context.Querylog.ToList();
            var config = context.Configurations.ToList();
            var model = querylog.Join(config, x => x.SerialNumber, y => y.SerialNumber.ToString(), (x, y) => new QueryLogViewModel
            {
                id=x.id,
                LocatioName=y.Description,
                SerialNumber=x.SerialNumber,
                ReceiveDate=x.ReceiveDate,
                QueryType=x.QueryType,
                ServerTime=x.ServerTime,
                SystemTime=x.SystemTime
            });
            var pageNumber = page ?? 1;
            var onePageOfqueryLog = model.ToPagedList(pageNumber, 100);
            return View(onePageOfqueryLog);
        }
    }
}