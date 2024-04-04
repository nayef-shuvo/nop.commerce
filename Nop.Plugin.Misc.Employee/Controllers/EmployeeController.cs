using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core.Caching;
using Nop.Plugin.Misc.EmployeeManagement.Domain;
using Nop.Plugin.Misc.EmployeeManagement.Factories;
using Nop.Plugin.Misc.EmployeeManagement.Models;
using Nop.Plugin.Misc.EmployeeManagement.Services;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Framework.Mvc.Routing;

namespace Nop.Plugin.Misc.EmployeeManagement.Controllers;

[Area(AreaNames.ADMIN)]
//[ValidateAntiForgeryToken]
public class EmployeeController : BasePluginController
{
    private readonly IEmployeeService _employeeService;
    private readonly INotificationService _notificationService;
    private readonly IEmployeeModelFactory _employeeModelFactory;
    private readonly IPermissionService _permissionService;
    private readonly IUrlRecordService _urlRecordService;
    private readonly INopUrlHelper _urlHelper;

    public EmployeeController(IEmployeeService employeeService, INotificationService notificationService, IEmployeeModelFactory employeeModelFactory, IPermissionService permissionService, IUrlRecordService urlRecordService, INopUrlHelper urlHelper)
    {
        _employeeService = employeeService;
        _notificationService = notificationService;
        _employeeModelFactory = employeeModelFactory;
        _permissionService = permissionService;
        _urlRecordService = urlRecordService;
        _urlHelper = urlHelper;
    }

    public IActionResult Index()
    {
        return RedirectToAction("List");
    }
    public async Task<ActionResult> List()
    {
        var model = await _employeeModelFactory.PrepareEmployeeSearchModelAsync(new EmployeeSearchModel());

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> List(EmployeeSearchModel searchModel)
    {
        var model = await _employeeModelFactory.PrepareEmployeeListModelAsync(searchModel);

        return Json(model);
    }

    public async Task<IActionResult> Create()
    {
        var model = await _employeeModelFactory.PrepareEmployeeModelAsync(new EmployeeModel(), null);

        return View(model);
    }

    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public ActionResult Create(EmployeeModel model, bool continueEditing)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var employee = model.ToEntity<EmployeeDomain>();

        _employeeService.Add(employee);
        _notificationService.SuccessNotification(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_ADD_NEW);

        if (!continueEditing)
            return RedirectToAction("List");

        return RedirectToAction("Edit", new { id = employee.Id });
    }



    public async Task<IActionResult> Edit(int id)
    {
        EmployeeDomain employee = _employeeService.Get(id);
        if (employee == null)
            return RedirectToAction("List");

        EmployeeModel model = await _employeeModelFactory.PrepareEmployeeModelAsync(null, employee);

        string seName = employee.Name.Replace(' ', '_').ToLower();
        var employeeUrl = await _urlHelper.RouteGenericUrlAsync<EmployeeDomain>(new { SeName = seName });

        //return LocalRedirectPermanent(employeeUrl);

        return View(model);
    }

    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Edit(EmployeeModel model, bool continueEditing)
    {
        var employee = _employeeService.Get(model.Id);

        if (employee == null)
            return RedirectToAction("List");

        if (!ModelState.IsValid)
        {
            model = await _employeeModelFactory.PrepareEmployeeModelAsync(model, employee);
            return RedirectToAction("List");
        }


        employee = model.ToEntity<EmployeeDomain>();

        _employeeService.Update(employee);
        _notificationService.SuccessNotification("Admin.Catalog.Emploees.Updated");

        if (!continueEditing)
            return RedirectToAction("List");

        return RedirectToAction("Edit", new { id = model.Id });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var employee = _employeeService.Get(id);

        if (employee == null)
            return RedirectToAction("List");

        _employeeService.Delete(employee);

        _notificationService.SuccessNotification("Admin.Catalog.Employees.Deleted");

        return RedirectToAction("List");
    }

    [HttpPost]
    public IActionResult DeleteSelected(ICollection<int> selectedIds)
    {
        if (selectedIds == null || selectedIds.Count == 0)
            return NoContent();
        try
        {

            foreach (int id in selectedIds)
            {
                EmployeeDomain employee = _employeeService.Get(id);
                if (employee != null)
                {
                    _employeeService.Delete(employee);
                }
            }
            _notificationService.SuccessNotification("Admin.Catalog.Employees.Deleted");

        }
        catch (Exception ex)
        {

        }
        return Json(new { Result = true });
    }
}
