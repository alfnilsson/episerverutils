namespace EPiServer.Templates.Alloy.Business.Menu
{
    using System.Web.Routing;

    using EPiServer.Framework;
    using EPiServer.Framework.Initialization;

    [InitializableModule]
    [ModuleDependency(typeof(Web.InitializationModule))]
    public class LogoutQuickNavigatorInitializer : IInitializableModule
    {
        private const string RouteName = "LogoutRedirect";

        public void Initialize(InitializationEngine context)
        {
            RouteTable.Routes.Add(RouteName, new Route("logout", new LogoutRedirectRouteHandler()));
        }

        public void Preload(string[] parameters) { }

        public void Uninitialize(InitializationEngine context)
        {
            RouteTable.Routes.Remove(RouteTable.Routes[RouteName]);
        }
    }
}