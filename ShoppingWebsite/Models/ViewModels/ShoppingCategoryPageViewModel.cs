using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingWebsite.Models.Pages;

namespace ShoppingWebsite.Models.ViewModels
{
    public class ShoppingCategoryPageViewModel : PageViewModel<SitePageData>
    {

        public ShoppingCategoryPageViewModel(SitePageData currentPage)
            :base (currentPage)
        {
            this.ShoppingPages = new List<ShoppingPage>();
            this.ShoppingCategoryPages = new List<ShoppingCategoryPage>();
           
        }
        public List<ShoppingPage> ShoppingPages { get; set; }
        public List<ShoppingCategoryPage> ShoppingCategoryPages { get; set; }

        public string CartUrl { get; set; }
    }
}