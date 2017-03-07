using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Models.ViewModel;

namespace SnifferManager.Controllers
{
    
    public class ConfigurationController : Controller
    {
        DeviceDbContext context;
        public ConfigurationController()
        {
            context = new DeviceDbContext();
        }

        [HttpGet]    
        [Route("config/all")]   
        public ActionResult Index()
        {
            var model = context.Configurations.ToList();
            return View(model);
        }

        [HttpGet]   
        [Route("config/add")]   
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("config/add")]
        public ActionResult Create(ConfigurationViewModel model)
        {
            var entity = new Configuration();
            entity.Description = model.Name;
            var lastSerialNumber=context.Configurations.Max(x => x.SerialNumber);
            entity.SerialNumber = ++lastSerialNumber;
            context.Configurations.Add(entity);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}