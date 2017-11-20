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
    public class ShoppingCartPageController : PageController<ShoppingCartPage>
    {
      
        //private readonly IContentRepository _contentRepository;

        //public ShoppingCartPageController(IContentRepository contentRepository)
        //{
        //    this._contentRepository = contentRepository;
        //}
        public ActionResult Index(ShoppingCartPage currentPage)
        {
            var vm = new ShoppingCartViewModel(currentPage);

            var cart = new ShoppingCartPage();
            HttpCookie cookies = Request.Cookies["ShoppingCart"];

            if (cookies != null)
            {
                cart.Size = cookies["SIZE"];
                cart.NumberOfItems = cookies["Itemsquantity"];

                vm.ProductIdsInCookie = new List<string>();
                vm.ProductIdsInCookie.Add(cart.NumberOfItems);
                vm.ProductIdsInCookie.Add(cart.Size);

                //Response.Write(cart.Size + "  " + cart.NumberOfItems);
                //return Content(cart.Size, cart.NumberOfItems);
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(ShoppingCartPage currentPage, string numberOfItems, int? price, string sizes, string userId, string desc)
        {
            var vm = new ShoppingCartViewModel(currentPage);

            HttpCookie cookie = new HttpCookie("ShoppingCart")
            {
                //Value = "Hello Cookie! CreatedOn: amount ordered:    " + numberOfItems + " and size:   " +
                //        sizes + "        " + DateTime.Now.ToShortTimeString(),
                Expires = DateTime.Now.AddDays(30),
                ["SIZE"] = sizes,
                ["Itemsquantity"] = numberOfItems,
            };

            this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);

            vm.ProductIdsInCookie = new List<string>();
            vm.ProductIdsInCookie.Add(numberOfItems);

            return View(vm);
        }
    }
}