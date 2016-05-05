using EPiServer.Find.UI;

namespace Toders.Web.Find
{
    public class WrappingFindUIConfiguration : IFindUIConfiguration
    {
        private readonly IFindUIConfiguration _originalFindUiConfiguration;

        public WrappingFindUIConfiguration(IFindUIConfiguration originalConfiguration)
        {
            _originalFindUiConfiguration = originalConfiguration;
        }

        // Here I only need to return my own roles that should have access to Find
        public string[] AllowedRoles
        {
            get
            {
                return new[] {"MyCustomFindRole"};
            }
        }

        /* Methds and properties below till use original implementation of IFindUIConfiguration */
        public string ClientSideResourceBaseUrl { get { return _originalFindUiConfiguration.ClientSideResourceBaseUrl; } }
        public string[] PublicRoutes { get { return _originalFindUiConfiguration.PublicRoutes; } }
        public string AdminProxyPath { get { return _originalFindUiConfiguration.AdminProxyPath; } }
        public string PublicProxyPath { get { return _originalFindUiConfiguration.PublicProxyPath; } }
        public string AbsolutePublicProxyPath()
        {
            return _originalFindUiConfiguration.AbsolutePublicProxyPath();
        }
    }
}