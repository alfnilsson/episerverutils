using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.ServiceLocation;

namespace Toders.Web
{
    public class ImageReplacer
    {
        /// <summary>
        /// Replaces all references to an old image with a new image
        /// </summary>
        /// <param name="oldImage">A ContentReference to the old image</param>
        /// <param name="newImage">The ContentReference to the new image</param>
        public void Replace(ContentReference oldImage, ContentReference newImage)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            IEnumerable<ReferenceInformation> referencesToContentWithOldImage = contentRepository.GetReferencesToContent(oldImage, false);
            foreach (ReferenceInformation referenceInformation in referencesToContentWithOldImage)
            {
                ContentData content = GetContentWithOldImage(referenceInformation, contentRepository);

                List<PropertyData> propertiesWithOldImage = GetPropertiesWithOldImage(oldImage, content);
                if (propertiesWithOldImage.Any() == false)
                {
                    continue;
                }

                var clone = content.CreateWritableClone() as ContentData;
                if (clone == null)
                {
                    continue;
                }

                ReplaceWithNewImage(newImage, propertiesWithOldImage, clone);

                contentRepository.Save((IContent)clone, SaveAction.Publish, AccessLevel.NoAccess);
            }
        }

        private static ContentData GetContentWithOldImage(ReferenceInformation referenceInformation,
            IContentRepository contentRepository)
        {
            ContentReference ownerContentLink = referenceInformation.OwnerID;
            CultureInfo ownerLanguage = referenceInformation.OwnerLanguage;
            ILanguageSelector selector = new LanguageSelector(ownerLanguage.Name);
            var content = contentRepository.Get<ContentData>(ownerContentLink, (LoaderOptions) selector);
            return content;
        }

        private static List<PropertyData> GetPropertiesWithOldImage(ContentReference newImage, ContentData content)
        {
            var propertiesWithOldImage = content.Property
                .Where(propertyData => propertyData.Value as ContentReference == newImage)
                .ToList();
            return propertiesWithOldImage;
        }

        private static void ReplaceWithNewImage(ContentReference newImage, List<PropertyData> propertiesWithOldImage, ContentData clone)
        {
            foreach (PropertyData propertyData in propertiesWithOldImage)
            {
                clone[propertyData.Name] = newImage;
            }
        }
    }
}