using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Nop.Plugin.Misc.CustomTheme.Infrastructure;
public class ViewLocationExpander : IViewLocationExpander
{
    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        const string THEME_KEY = "nop.themename";


        if (context.Values.TryGetValue(THEME_KEY, out var theme))
        {
             viewLocations = new[] {
                    $"/Plugins/Misc.CustomTheme/Themes/{theme}/Views/Shared/{{0}}.cshtml",
                    $"/Plugins/Misc.CustomTheme/Themes/{theme}/Views/{{1}}/{{0}}.cshtml"
                }.Concat(viewLocations);
        }
        else
        {
            viewLocations = new[] {
                $"/Plugins/Misc.CustomTheme/Views/Shared/{{0}}.cshtml",
                $"/Plugins/Misc.CustomTheme/Views/{{1}}/{{0}}.cshtml"
            }.Concat(viewLocations);

        }

        return viewLocations;
    }

    public void PopulateValues(ViewLocationExpanderContext context)
    {
    }
}
