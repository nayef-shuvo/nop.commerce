
using Nop.Core.Caching;

namespace Nop.Plugin.Misc.EmployeeManagement;

public static class EmployeeManagementDefaults
{
    public const string ADMIN_CATALOG_EMPLOYEES = "Admin.Catalog.Employees";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_NAME = "Admin.Catalog.Employees.Fields.Name";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_NAME_HINT = "Admin.Catalog.Employees.Fields.Name.Hint";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_EMAIL = "Admin.Catalog.Employees.Fields.Email";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_EMAIL_HINT = "Admin.Catalog.Employees.Fields.Email.Hint";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_PHONE = "Admin.Catalog.Employees.Fields.Phone";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_PHONE_HINT = "Admin.Catalog.Employees.Fields.Phone.Hint";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_DATE_OF_BIRTH = "Admin.Catalog.Employees.Fields.DateOfBirth";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_DATE_OF_BIRTH_HINT = "Admin.Catalog.Employees.Fields.DateOfBirth.Hint";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_JOINED_DATE = "Admin.Catalog.Employees.Fields.JoinedDate";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_JOINED_DATE_HINT = "Admin.Catalog.Employees.Fields.JoinedDate.Hint";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_LEAVE_DATE = "Admin.Catalog.Employees.Fields.LeaveDate";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_LEAVE_DATE_HINT = "Admin.Catalog.Employees.Fields.LeaveDate.Hint";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_CURRENTLY_WORKING = "Admin.Catalog.Employees.Fields.CurrentlyWorking";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_CURRENTLY_WORKING_HINT = "Admin.Catalog.Employees.Fields.CurrentlyWorking.Hint";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_EMPLOYEE_ROLE_NAME = "Admin.Catalog.Employees.Fields.EmployeeRoleName";

    public const string ADMIN_CATALOG_EMPLOYEES_FIELDS_EMPLOYEE_ROLE_NAME_HINT = "Admin.Catalog.Employees.Fields.EmployeeRoleName.Hint";

    public const string ADMIN_CATALOG_EMPLOYEES_ADD_NEW = "Admin.Catalog.Employees.AddNew";

    public const string ADMIN_CATALOG_EMPLOYEES_BACK_TO_LIST = "Admin.Catalog.Employees.BackToList";

    public const string ADMIN_CATALOG_EMPLOYEES_INFO = "Admin.Catalog.Employees.Info";

    public const string ADMIN_CATALOG_EMPLOYEES_EDIT_EMPLOYEE_DETAILS = "Admin.Catalog.Employees.EditEmployeeDetails";

    public const string ADMIN_CATALOG_EMPLOYEES_EDIT = "Admin.Catalog.Employees.Edit";

    public const string ADMIN_CATALOG_EMPLOYEES_COPY = "Admin.Catalog.Employees.Copy";

    public static CacheKey EmployeeCacheKey => new("Admin.Catalog.Employees.Id.{0}") { CacheTime = 5 };

    public static CacheKey EmployeePageCacheKey => new("Admin.Catalog.Employees.{0}-{1}-{2}") { CacheTime = 5};
}
