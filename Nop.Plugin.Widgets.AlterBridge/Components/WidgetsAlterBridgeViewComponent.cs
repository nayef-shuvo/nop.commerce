using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Plugins;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.AlterBridge.Components;
public class WidgetsAlterBridgeViewComponent : NopViewComponent
{
    public IViewComponentResult Invoke(string widgetZone, object additionalData)
    {
        return View("~/Plugins/Widgets.AlterBridge/Views/Default.cshtml");
    }
}
