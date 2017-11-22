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
using ShoppingWebsite.Business;
using ShoppingWebsite.Models.Pages;
using ShoppingWebsite.Models.ViewModels;

namespace ShoppingWebsite.Controllers
{
    public class ShoppingCartPageController : PageController<ShoppingCartPage>
    {
      
        public ActionResult Index(ShoppingCartPage currentPage)
        {
            var vm = new ShoppingCartViewModel(currentPage);

            var cart = new ShoppingCartPage();
            HttpCookie cookies = Request.Cookies["ShoppingCart"];

            if (cookies != null)
            {
                cart.Size = cookies["SIZE"];
                cart.NumberOfItems = cookies["Quantity"];

                vm.ProductIdsInCookie = new List<string>();
                vm.ProductIdsInCookie.Add(cart.NumberOfItems);
                vm.ProductIdsInCookie.Add(cart.Size);
            }

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(ShoppingCartPage currentPage, string numberOfItems, string sizes)
        {
            var vm = new ShoppingCartViewModel(currentPage);
            var productCookie = new CookiesHelper();
            HttpCookie cookie = new HttpCookie("ShoppingCart")
            {
                Expires = DateTime.Now.AddDays(30),
                ["SIZE"] = sizes,
                ["Quantity"] = numberOfItems,
            };
            productCookie.GetCookies(cookie.Name, cookie["Quantity"], cookie["Size"]);

            vm.ProductIdsInCookie = new List<string>
            {
                numberOfItems,
                sizes
            };


            return View(vm);
        }
    }
}