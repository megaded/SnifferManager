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
        public ActionResult Index()
        {
            var model = context.Configurations.ToList();
            return View(model);
        }
        [HttpGet]          
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]        
        public ActionResult Create(string name)
        {
            var entity = new Configuration();
            entity.Description = name;
            var lastSerialNumber=context.Configurations.Max(x => x.SerialNumber);
            entity.SerialNumber = ++lastSerialNumber;
            context.Configurations.Add(entity);
            context.SaveChanges();
            return PartialView("SerialNumber", entity.SerialNumber.ToString());
        }
    }
}