using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.Misc.CustomTheme.Infrastructure;
public class RouteProvider : IRouteProvider
{
    public int Priority => 0;

    public void RegisterRoutes(IEndpointRouteBuilder endpointRouteBuilder)
    {
        endpointRouteBuilder.MapControllerRoute(
            name: "Plugin.Misc.CustomTheme.Configure",
            pattern: "/Admin/CustomTheme/Configure/",
            defaults: new { controller = "CustomTheme", action = "Configure", area = AreaNames.ADMIN}
            );
    }
}
