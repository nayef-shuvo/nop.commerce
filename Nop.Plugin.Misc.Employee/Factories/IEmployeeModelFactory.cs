using System.Threading.Tasks;
using Nop.Plugin.Misc.EmployeeManagement.Domain;
using Nop.Plugin.Misc.EmployeeManagement.Models;
using Nop.Web.Areas.Admin.Models.Catalog;

namespace Nop.Plugin.Misc.EmployeeManagement.Factories;
public interface IEmployeeModelFactory
{
    Task<EmployeeSearchModel> PrepareEmployeeSearchModelAsync(EmployeeSearchModel searchModel);
    Task<EmployeeListModel> PrepareEmployeeListModelAsync(EmployeeSearchModel searchModel);

    Task<EmployeeModel> PrepareEmployeeModelAsync(EmployeeModel model, EmployeeDomain employee);
}
