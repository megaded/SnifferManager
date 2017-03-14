using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Models.ViewModel;
using PagedList.Mvc;
using PagedList;
using SnifferManager.Models;
using System.Text;

namespace SnifferManager.Controllers
{
    public class ParamsController : Controller
    {
        DeviceDbContext context;
        public ParamsController()
        {
            context = new DeviceDbContext();
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            var param = context.Params.ToList();
            var config = context.Configurations.ToList();
            var model = param.Join(config, x => x.serial_number, y => y.SerialNumber.ToString(), (x, y) => new ParamsViewModel
            {
                id = x.id,
                LocatioName = y.Description,
                command_body = Encoding.UTF8.GetString(x.command_body),
                serial_number = x.serial_number,
                receive_date = x.receive_date,
                packet_number = x.packet_number,
                packet_size = x.packet_size,
                cmd = x.cmd,
                cmd_request = x.cmd_request,
                crc16 = x.crc16,
                parsed = x.parsed,
                server_time = x.server_time,
                system_time = x.system_time
            }).ToList();
            var pageNumber = page ?? 1;
            var onePageOfParams = model.ToPagedList(pageNumber, 100);
            ViewBag.Title = "Данные";
            return View(onePageOfParams);
        }

        [HttpGet]
        public ActionResult Location(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Params(DateTime BeginDate, DateTime EndDate, int LocationId)
        {
            return PartialView();
        }
    }
}