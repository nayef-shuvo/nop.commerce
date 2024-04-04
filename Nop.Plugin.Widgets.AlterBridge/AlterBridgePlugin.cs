using Nop.Plugin.Widgets.AlterBridge.Components;
using Nop.Services.Cms;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.AlterBridge;

public class AlterBridge : BasePlugin, IWidgetPlugin
{
    public bool HideInWidgetList => false;

    public Type GetWidgetViewComponent(string widgetZone)
    {
        return typeof(WidgetsAlterBridgeViewComponent);
    }

    public Task<IList<string>> GetWidgetZonesAsync()
    {
        return Task.FromResult<IList<string>>( [PublicWidgetZones.HomepageBeforeProducts, PublicWidgetZones.HomepageBottom] );
    }

    public override async Task InstallAsync()
    {
        await base.InstallAsync();
    }
    public override async Task UninstallAsync()
    {
        await base.UninstallAsync();
    }
}