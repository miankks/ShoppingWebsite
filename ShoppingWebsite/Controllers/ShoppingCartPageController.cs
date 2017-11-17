using System.Collections.Generic;
using System.Linq;
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
            var categoryPages = _contentRepository.GetChildren<ShoppingCartPage>(currentPage.ContentLink).ToList();

            var model = new ShoppingCartViewModel(currentPage)
            {
                ShoppingCartPages = categoryPages
            };

            return View(model);
        }
    }
}