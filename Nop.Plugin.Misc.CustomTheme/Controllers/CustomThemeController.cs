using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Services.Configuration;
using Nop.Services.Messages;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Misc.CustomTheme.Controllers;

[Area(AreaNames.ADMIN)]
public class CustomThemeController : BasePluginController
{
    private readonly ISettingService _settingService;
    private readonly INotificationService _notificationService;
    public CustomThemeController(ISettingService settingService, INotificationService notificationService)
    {
        _settingService = settingService;
        _notificationService = notificationService;
    }

    public IActionResult Configure()
    {
        var model = _settingService.LoadSetting<CustomThemeSettings>() ?? new CustomThemeSettings();
        return View("Plugins/Misc.CustomTheme/Views/Configure.cshtml", model);
    }

    [HttpPost]
    public IActionResult Configure(CustomThemeSettings settings)    
    {
        _settingService.SaveSetting(settings);

        _notificationService.SuccessNotification("Custom settings configuration added successfully");

        return Configure();
    }
}
