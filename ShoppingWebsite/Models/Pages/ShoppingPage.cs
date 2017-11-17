using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace ShoppingWebsite.Models.Pages
{
    [ContentType(DisplayName = "ShoppingPage", GUID = "38463357-e7e3-4300-9985-1fa4111ad05d", Description = "")]
    public class ShoppingPage : SitePageData
    {
        [Display(
            Name = "Product Id",
            Description = "Product Id",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Id {
            get
            {
                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                char[] stringChars = new char[7];
                Random random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                string finalString = new String(stringChars);
                return finalString;
            }
        }

        [Display(
            Name = "Product Image",
            Description = "Product Image",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference ProductImage { get; set; }

        [Display(
            Name = "Product name",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual string ProductName { get; set; }

        [Display(
            Name = "Product price",
            GroupName = "Price",
            Order = 20)]
        public virtual double ProductPriceFor { get; set; }

        [Display(
            Name = "Product Moms",
            GroupName = "Price",
            Order = 20)]
        public virtual double Moms => ProductPriceFor * 0.25;

        [Display(
            Name = "Product description",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        public virtual XhtmlString ProductDecscription { get; set; }

        [Display(
            Name = "Product content area",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        [CultureSpecific]
        public virtual ContentArea ProductContentArea { get; set; }

        //[Display(
        //    Name = "Product Color",
        //    GroupName = SystemTabNames.Content,
        //    Order = 60)]
        //public virtual IList<SelectListItem> Colors { get; set; }

        //[Display(
        //    Name = "Product size",
        //    GroupName = SystemTabNames.Content,
        //    Order = 70)]
        //public virtual IList<SelectListItem> Sizes { get; set; }

        //[Display(
        //    Name = "Product color string",
        //    GroupName = SystemTabNames.Content,
        //    Order = 80)]
        //public virtual string Color { get; set; }

        //[Display(
        //    Name = "Product size string",
        //    GroupName = SystemTabNames.Content,
        //    Order = 80)]
        //public virtual string Size { get; set; }

        //[Display(
        //    Name = "Available?",
        //    GroupName = SystemTabNames.Content,
        //    Order = 80)]
        //public virtual bool IsAvailable { get; set; }
    }
}