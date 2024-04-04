using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Misc.EmployeeManagement;

public class MiscEmployeePlugin : BasePlugin, IMiscPlugin, IAdminMenuPlugin
{

    private readonly ILocalizationService _localizationService;

    public MiscEmployeePlugin(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
    }
    public override string GetConfigurationPageUrl()
    {
        return base.GetConfigurationPageUrl();
    }

    public override async Task InstallAsync()
    {
        await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
        {
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES] = "Employees",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_NAME] = "Name",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_EMAIL] = "Email address",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_PHONE] = "Phone number",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_DATE_OF_BIRTH] = "Date of birth",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_JOINED_DATE] = "Join date",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_LEAVE_DATE] = "Leave date",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_CURRENTLY_WORKING] = "Currently working",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_EMPLOYEE_ROLE_NAME] = "User role",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_ADD_NEW] = "Add a new employee",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_BACK_TO_LIST] = "back to employee list",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_INFO] = "Employee info",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_EDIT_EMPLOYEE_DETAILS] = "Edit employee details",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_EDIT] = "Edit employee details",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_COPY] = "Copy employee",

            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_NAME_HINT] = "Name of the employee",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_EMAIL_HINT] = "Email address of the employee",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_PHONE_HINT] = "Phone number of the employee",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_DATE_OF_BIRTH_HINT] = "Date of birth of the employee",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_JOINED_DATE_HINT] = "Joining date of the employee",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_LEAVE_DATE_HINT] = "Leave date of the employee",
            [EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_EMPLOYEE_ROLE_NAME_HINT ] = "Role of the employee",

        });


        await base.InstallAsync();
    }

    public async Task ManageSiteMapAsync(SiteMapNode rootNode)
    {
        var catalogNode = rootNode.ChildNodes.FirstOrDefault(node => node.SystemName == "Catalog");
        if (catalogNode != null)
        {
            var employeeNode = new SiteMapNode
            {
                Title = "Employees",
                SystemName = "EmployeeNode",
                ControllerName = "Employee",
                ActionName = "List",
                Visible = true,
                OpenUrlInNewTab = false,
                IconClass = "far fa-dot-circle",

            };
            catalogNode.ChildNodes.Add(employeeNode);
        }
        await Task.CompletedTask;
    }

    public override async Task UninstallAsync()
    {
        await _localizationService.DeleteLocaleResourcesAsync("Admin.Catalog.Employees");
        await base.UninstallAsync();
    }

}
