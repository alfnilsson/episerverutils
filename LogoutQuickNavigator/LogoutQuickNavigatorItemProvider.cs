using System.Collections.Generic;

namespace EPiServer.Templates.Alloy.Business.Menu
{
    using EPiServer.Core;
    using EPiServer.ServiceLocation;
    using EPiServer.Web;
    using EPiServer.Web.PageExtensions;
    using EPiServer.Web.Routing;

    [ServiceConfiguration(typeof(IQuickNavigatorItemProvider))]
    public class LogoutQuickNavigatorItemProvider : IQuickNavigatorItemProvider
    {
        private readonly IContentLoader contentLoader;

        public int SortOrder
        {
            get
            {
                return 10;
            }
        }

        public LogoutQuickNavigatorItemProvider(IContentLoader contentLoader)
        {
            this.contentLoader = contentLoader;
        }

        public IDictionary<string, QuickNavigatorMenuItem> GetMenuItems(ContentReference currentContent)
        {
            var urlBuilder = new UrlBuilder("/logout");
            if (this.IsPageData(currentContent))
            {
                var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
                string url = urlResolver.GetUrl(currentContent);

                urlBuilder.QueryCollection.Add("ReturnUrl", url);
            }

            return new Dictionary<string, QuickNavigatorMenuItem> {
                {
                    "customlogout",
                    new QuickNavigatorMenuItem("/shell/cms/menu/logout", urlBuilder.ToString(), null, "true", null)
                }
            };
        }

        private bool IsPageData(ContentReference currentContentLink)
        {
            return this.contentLoader.Get<IContent>(currentContentLink) is PageData;
        }
    }
}