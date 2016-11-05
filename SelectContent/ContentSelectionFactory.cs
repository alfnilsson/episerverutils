using System.Collections.Generic;
using System.Linq;

using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;

namespace Toders.SelectContent
{
    public class ContentSelectionFactory<TContent> : ISelectionFactory
        where TContent : IContentData
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

            var allContent = new List<SelectItem>();

            allContent.Add(new SelectItem());

            // Find all instances of Blocks that implements TContent
            foreach (var contentType in contentTypeRepository.List())
            {
                if (typeof(TContent).IsAssignableFrom(contentType.ModelType))
                {
                    // ListContentOfContentType gives me all versions of the blocks, so we're filtering out to only get the published version
                    IList<ContentUsage> contentUsages = ServiceLocator.Current.GetInstance<IContentModelUsage>()
                        .ListContentOfContentType(contentType);

                    allContent.AddRange(
                        contentUsages
                            .Where(x => contentLoader.Get<IContent>(x.ContentLink).IsDeleted == false)
                            .OrderByDescending(x => x.ContentLink.WorkID)
                            .Select(x => new SelectItem
                            {
                                Text = x.Name,
                                Value = x.ContentLink.ToReferenceWithoutVersion()
                            })
                            .Distinct(new Comparer()));
                }
            }

            return allContent.OrderBy(item => item.Text).ToList();
        }

        private class Comparer : IEqualityComparer<SelectItem>
        {
            public bool Equals(SelectItem x, SelectItem y)
            {
                var value = x.Value as ContentReference;
                if (value == null)
                {
                    return false;
                }

                var secondValue = y.Value as ContentReference;
                if (secondValue == null)
                {
                    return false;
                }

                return value.Equals(secondValue, true);
            }

            public int GetHashCode(SelectItem obj)
            {
                return obj.Value.GetHashCode();
            }
        }
    }
}