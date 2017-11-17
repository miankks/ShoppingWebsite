using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;

namespace ShoppingWebsite.Models.Pages
{
    [SiteContentType(
        GroupName = Global.GroupNames.Products)]
    [SiteImageUrl(Global.StaticGraphicsFolderPath + "page-type-thumbnail-product.png")]
    [ContentType(DisplayName = "ShoppingCategoryPage", GUID = "26de6c2f-035d-4fc6-b417-b7ea1d9426c1", Description = "")]
    [AvailableContentTypes(
        Availability.Specific,
        Include = new[] { typeof(ShoppingPage), typeof(ShoppingCategoryPage) })]
    public class ShoppingCategoryPage : SitePageData
    {
        [Display(
            Name = "Main Product Image",
            Description = "Product Image",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference MainProductImage { get; set; }
    }
}