using System;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Data;
using Nop.Plugin.Misc.EmployeeManagement.Domain;
using Nop.Plugin.Misc.EmployeeManagement.Models;
using Nop.Plugin.Misc.EmployeeManagement.Utils;

namespace Nop.Plugin.Misc.EmployeeManagement.Services;
public class EmployeeService : IEmployeeService
{
    private readonly IRepository<EmployeeDomain> _employeeRepository;
    private readonly IStaticCacheManager _staticCacheManager;

    public EmployeeService(IRepository<EmployeeDomain> employeeRepository, IStaticCacheManager staticCacheManager)
    {
        _employeeRepository = employeeRepository;
        _staticCacheManager = staticCacheManager;
    }

    public void Add(EmployeeDomain employee)
    {
        _employeeRepository.Insert(employee);
    }

    public void Delete(EmployeeDomain employee)
    {
        _employeeRepository.Delete(employee);

        var id = employee.Id;
        var cacheKey = _staticCacheManager.PrepareKey(EmployeeManagementDefaults.EmployeeCacheKey, id);
        _staticCacheManager.RemoveAsync(cacheKey);
    }

    public EmployeeDomain Get(int id)
    {
        var cacheKey = _staticCacheManager.PrepareKey(EmployeeManagementDefaults.EmployeeCacheKey, id);

        var employee = _staticCacheManager.GetAsync(cacheKey, () => _employeeRepository.GetById(id));

        return employee.Result;
    }

    public async Task<IPagedList<EmployeeDomain>> GetAll(EmployeeSearchModel searchModel = null, int pageIndex = 0, int pageSize = 10)
    {
        var cacheKey = _staticCacheManager.PrepareKey(EmployeeManagementDefaults.EmployeePageCacheKey, searchModel.GetHashCode(), pageIndex, pageSize);

        var employees = await _staticCacheManager.GetAsync(cacheKey, async () =>
        {
            var query = _employeeRepository.Table;

            if (!string.IsNullOrEmpty(searchModel.SearchEmployeeName))
            {
                var searchEmployeeName = searchModel.SearchEmployeeName.Trim();
                query = query.Where(e => e.Name.Contains(searchEmployeeName, StringComparison.OrdinalIgnoreCase));
            }
            if (!string.IsNullOrEmpty(searchModel.SearchEmailAddress))
            {
                var searchEmailAddress = searchModel.SearchEmailAddress.Trim();
                query = query.Where(e => e.Email.Contains(searchEmailAddress, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(searchModel.SearchPhoneNo))
            {
                var searchPhoneNo = searchModel.SearchPhoneNo.Trim();
                query = query.Where(e => e.Phone.Contains(searchPhoneNo, StringComparison.OrdinalIgnoreCase));
            }

            if (searchModel.CurrentlyWorking)
            {
                query = query.Where(e => !e.LeaveDate.HasValue);
            }

            if (searchModel.EmployeeRole != EmployeeRole.All)
            {
                query = query.Where(e => e.EmployeeRole == searchModel.EmployeeRole);
            }

            var employeePagedList = await query.ToPagedListAsync(searchModel.Page - 1, searchModel.PageSize);
            return employeePagedList;
        });

        return employees;
    }

    public void Update(EmployeeDomain employee)
    {
        _employeeRepository.Update(employee);

        var id = employee.Id;
        var cacheKey = _staticCacheManager.PrepareKey(EmployeeManagementDefaults.EmployeeCacheKey, id);
        _staticCacheManager.RemoveAsync(cacheKey);
    }
}
