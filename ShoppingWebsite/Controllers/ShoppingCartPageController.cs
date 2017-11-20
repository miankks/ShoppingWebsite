using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using ShoppingWebsite.Models.Pages;
using ShoppingWebsite.Models.ViewModels;

namespace ShoppingWebsite.Controllers
{
    public class ShoppingCartPageController : PageControllerBase<ShoppingCartPage>
    {
      
        private readonly IContentRepository _contentRepository;

        public ShoppingCartPageController(IContentRepository contentRepository)
        {
            this._contentRepository = contentRepository;
        }
        public ActionResult Index(ShoppingCartPage currentPage)
        {
            //var categoryPages = _contentRepository.GetChildren<ShoppingCartPage>(currentPage.ContentLink).ToList();
            //var model = new ShoppingCartViewModel(currentPage)
            //{
            //    ShoppingCartPages = categoryPages
            //};
            var cart = new ShoppingCartPage();
            var shop = new ShoppingCartViewModel(currentPage);
            HttpCookie cookies = Request.Cookies["ShoppingCart"];
            if (cookies != null)
            {
                cart.Size = cookies["SIZE"];
                cart.NumberOfItems = cookies["Itemsquantity"];
                Response.Write(cart.Size + "  " + cart.NumberOfItems);
                return View(shop);
            }
            else
            {
                Response.Write("not found   ");
                return Content("Not recieved");
            }
        }

        [HttpPost]
        public void Index(string dropdowntipo, int? price, string sizes, string userId)
        {
         
            HttpCookie cookie = new HttpCookie("ShoppingCart")
            {
                Value = "Hello Cookie! CreatedOn: amount ordered:    " + dropdowntipo + " and size:   " +
                        sizes + "        " + DateTime.Now.ToShortTimeString(),
                Expires = DateTime.Now.AddDays(30),
                ["SIZE"] = sizes,
                ["Itemsquantity"] = dropdowntipo,
            };


            this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
            Response.Redirect("Index");
            //return Content(cookie.Value);
        }
    }
}