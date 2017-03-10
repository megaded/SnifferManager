using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Models.ViewModel;

namespace SnifferManager.Controllers
{
    public class LogMessageTypesController : Controller
    {
        DeviceDbContext context;
        public LogMessageTypesController()
        {
            context = new DeviceDbContext();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = context.Logmessagetypes.Select(x => new LogMessageTypesViewModel
            {
                id=x.id,
                Description=x.Description
            }).ToList();
            return View(model);
        }
    }
}