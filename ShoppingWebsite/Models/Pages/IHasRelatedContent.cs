using EPiServer.Core;

namespace ShoppingWebsite.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
