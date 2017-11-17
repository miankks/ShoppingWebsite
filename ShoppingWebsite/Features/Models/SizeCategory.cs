using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Shell.ObjectEditing;
using ISelectionFactory = EPiServer.Personalization.VisitorGroups.ISelectionFactory;

namespace ShoppingWebsite.Features.Models
{
    public class SizeCategory : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            return new ISelectItem[] {

                new SelectItem()
                {
                    Value = null
                },
                new SelectItem()
                {
                    Text = "Small",
                    Value = "S"
                },

                new SelectItem()
                {
                    Text = "Medium",
                    Value = "M"
                },

                new SelectItem()
                {
                    Text = "Large",
                    Value = "L"
                }
            };
        }
    }
}