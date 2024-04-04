using System.Threading.Tasks;
using Nop.Core;
using Nop.Plugin.Misc.EmployeeManagement.Domain;
using Nop.Plugin.Misc.EmployeeManagement.Models;

namespace Nop.Plugin.Misc.EmployeeManagement.Services;
public interface IEmployeeService
{
    Task<IPagedList<EmployeeDomain>> GetAll(EmployeeSearchModel searchModel = null, int pageIndex = 0, int pageSize = 10);
    EmployeeDomain Get(int id);
    void Add(EmployeeDomain employee);
    void Update(EmployeeDomain employee);
    void Delete(EmployeeDomain employee);
}
