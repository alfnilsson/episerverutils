namespace EPiServer.Templates.Alloy.Business.Menu
{
    using System;
    using System.Web;
    using System.Web.Compilation;
    using System.Web.Routing;

    using EPiServer.Util;

public class LogoutRedirectRouteHandler : IRouteHandler
{
    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        var logout = BuildManager.CreateInstanceFromVirtualPath("/Util/Logout.aspx", typeof(Logout)) as Logout;
        if (logout == null)
        {
            throw new Exception();
        }

        logout.PreRender += this.LogoutOnPreRender;
        return logout;
    }

    private void LogoutOnPreRender(object sender, EventArgs eventArgs)
    {
        var returnUrl = HttpContext.Current.Request.QueryString["ReturnUrl"];
        HttpContext.Current.Response.Redirect(returnUrl);
    }
}
}