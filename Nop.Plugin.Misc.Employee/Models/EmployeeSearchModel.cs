using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Plugin.Misc.EmployeeManagement.Utils;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.EmployeeManagement.Models;
public record EmployeeSearchModel : BaseSearchModel
{
    [NopResourceDisplayName(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_NAME)]
    public string SearchEmployeeName { get; set; }

    [NopResourceDisplayName(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_EMAIL)]
    public string SearchEmailAddress { get; set; }

    [NopResourceDisplayName("Is Currently Working Here?")]
    public bool CurrentlyWorking { get; set; } = false;

    [NopResourceDisplayName(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_PHONE)] 
    public string SearchPhoneNo { get; set; }

    [NopResourceDisplayName(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_EMPLOYEE_ROLE_NAME)]
    public EmployeeRole EmployeeRole { get; set; }

    public IList<SelectListItem> AvailableRoles { get; set; }

    public EmployeeSearchModel()
    {
        AvailableRoles = Enum.GetValues(typeof(EmployeeRole)).Cast<EmployeeRole>()
                                            .Select(e => new SelectListItem
                                            {
                                                Text = e.ToString(),
                                                Value = ((int)e).ToString()
                                            }).ToList();
    }
}
