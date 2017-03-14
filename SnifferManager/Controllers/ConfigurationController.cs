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
            ViewBag.Title = "Настройки";
            return View(model);
        }

        [HttpGet]          
        public ActionResult Add()
        {
            ViewBag.Title = "Новый арендатор";
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var entity = context.Configurations.Find(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            var model = new ConfigurationViewModel();
            model.SerialNumber = entity.SerialNumber;
            model.Name = entity.Description;
            model.WorkMode = entity.WorkMode;
            model.KkmTypeString = entity.KkmTypeString;
            model.BaudRate = entity.BaudRate;
            model.Parity = entity.Parity;
            model.StopBits = entity.StopBits;
            model.DataBits = entity.DataBits;
            model.PrinterPort = entity.PrinterPort;
            model.CashPort = entity.CashPort;
            model.UsbDeviceName = entity.UsbDeviceName;
            model.UsbManufacturerName = entity.UsbManufacturerName;
            model.UsbKey = entity.UsbKey;
            model.EnableComSniffer = entity.EnableComSniffer;
            model.EnableUsbSniffer = entity.EnableUsbSniffer;
            model.CashDeskNumber = entity.CashDeskNumber;
            ViewBag.Title = $"Редактировать {model.Name} {model.SerialNumber}";
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit()
        {
            return View();
        }
    }
}