using Nop.Plugin.Misc.EmployeeManagement.Utils;
using System;
using Nop.Web.Framework.Models;
using System.ComponentModel.DataAnnotations;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.EmployeeManagement.Models;
public record EmployeeModel : BaseNopEntityModel
{
    [NopResourceDisplayName(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_NAME)]
    public string Name { get; set; }

    [NopResourceDisplayName(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_EMAIL)]
    public string Email { get; set; }

    [NopResourceDisplayName(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_PHONE)]
    public string Phone { get; set; }

    [UIHint("DateNullable")]
    [NopResourceDisplayName(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_DATE_OF_BIRTH)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly? DateOfBirth { get; set; }

    [UIHint("DateNullable")]
    [NopResourceDisplayName(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_JOINED_DATE)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateOnly? JoinedDate { get; set; }

    [UIHint("DateNullable")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [NopResourceDisplayName(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_LEAVE_DATE)]
    public DateOnly? LeaveDate { get; set; } = null;

    [NopResourceDisplayName(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_EMPLOYEE_ROLE_NAME)]
    public string EmployeeRoleName { get; set; }

    [NopResourceDisplayName(EmployeeManagementDefaults.ADMIN_CATALOG_EMPLOYEES_FIELDS_CURRENTLY_WORKING)]

    public bool CurrentlyWorking { get; set; }
}
