﻿using System;
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
            this.ProductIdsInCookie = new List<string>();
            this.ShoppingPagesInCart = new List<CartItem>();
        }

        public List<string> ProductIdsInCookie { get; set; }

        public List<CartItem> ShoppingPagesInCart { get; set; }

        public List<ShoppingCartPage> ShoppingCartPages { get; set; }
        public class CartItem
        {
            public ShoppingPage ShoppingPage { get; set; }

            public int NumberOfItems { get; set; }

            public double CartItemTotal { get; set; }

            public string Size { get; set; }
        }

        public double CartTotal { get; set; }
    }
}