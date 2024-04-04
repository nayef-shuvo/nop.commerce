using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Nop.Plugin.Misc.EmployeeManagement.Infrastructure;
public class ViewLocationExpander : IViewLocationExpander
{
    public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
    {
        viewLocations = new[]
        {
            $"/Plugins/Misc.EmployeeManagement/Views/Shared/{{0}}.cshtml",
            $"/Plugins/Misc.EmployeeManagement/Views/{{1}}/{{0}}.cshtml",

        }.Concat(viewLocations);
        
        return viewLocations;
    }

    public void PopulateValues(ViewLocationExpanderContext context)
    {
    }
}
