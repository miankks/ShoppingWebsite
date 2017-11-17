using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingWebsite.Models.Pages;

namespace ShoppingWebsite.Models.ViewModels
{
    public class ShoppingCartViewModel : PageViewModel<SitePageData>
    {
        public ShoppingCartViewModel(SitePageData currentPage)
            :base(currentPage)
        {
            this.ShoppingCartPages = new List<ShoppingCartPage>();
        }

        public List<ShoppingCartPage> ShoppingCartPages { get; set; }
    }
}