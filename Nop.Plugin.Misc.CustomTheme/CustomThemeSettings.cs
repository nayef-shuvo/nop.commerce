using System;
using Nop.Core.Configuration;

namespace Nop.Plugin.Misc.CustomTheme;
public class CustomThemeSettings : ISettings
{
    public string Name { get; set; }
    public string Message { get; set; }
    public DateOnly Date { get; set; }
}
