using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using EPiServer.Web.PageExtensions;
using ShoppingWebsite.Models.Pages;
using ShoppingWebsite.Models.ViewModels;

namespace ShoppingWebsite.Controllers
{
    public class ShoppingCategoryPageController : PageControllerBase<ShoppingCategoryPage>
    {
        private readonly IContentRepository _contentRepository;
       
        public ShoppingCategoryPageController(IContentRepository contentRepository)
        {
            this._contentRepository = contentRepository;
        }
        public ActionResult Index(ShoppingCategoryPage currentPage)
        {
            var categoryPages = _contentRepository.GetChildren<ShoppingCategoryPage>(currentPage.ContentLink).ToList();

            var model = new ShoppingCategoryPageViewModel(currentPage)
            {
                ShoppingCategoryPages = categoryPages
            };
            
            var shoppingLinks = _contentRepository.GetChildren<ShoppingPage>(currentPage.ContentLink).ToList();
            model.ShoppingPages = shoppingLinks;
            TempData["successmessage"] = "Objektet har lagts i korgen!";

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string dropdowntipo, int? price, string sizes)
        {
            string all = dropdowntipo +" " +" "+ sizes +" has been recieved";
            HttpCookie cookie =
                new HttpCookie("Cookie")
                {
                    Value = "Hello Cookie! CreatedOn: amount ordered: <b>" +dropdowntipo +"</b> and size: <b>" + sizes +"</b> " + DateTime.Now.ToShortTimeString(),
                    Expires = DateTime.Now.AddDays(90),
                    Name = "ShoppingCart",
                };
            this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            return Content(cookie.Value);
        }

        //[HttpPost]
        //public ActionResult Index(string hello)
        //{
        //    string a = hello;
        //    return Content(a);
        //}
    }
}