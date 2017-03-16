using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SnifferManager.Models.ViewModel;
using PagedList;


namespace SnifferManager.Controllers
{
    public class ArticleController : Controller
    {
        DeviceDbContext context;

        public ArticleController()
        {
            context = new DeviceDbContext();
        }

        [HttpGet]
        public ActionResult Index(int? page)
        {
            var model = context.Articles.Select(x => new ArticleViewModel
            {
                ArtNumber=x.ArtNumber,
                Count=x.Count,
                Group=x.Group,
                Name=x.Name,
                Price=x.Price,
                TotalPrice=x.TotalPrice,
                CheckId=x.CheckId,
                id=x.id
            }).ToList();
            var pageNumber = page ?? 1;
            var onePageOfArticle = model.ToPagedList(pageNumber, 100);
            ViewBag.Title = "Товары";
            return View(onePageOfArticle);
        }
    }
}