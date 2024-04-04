using System;
using System.Linq;
using System.Threading.Tasks;
using Nop.Plugin.Misc.EmployeeManagement.Domain;
using Nop.Plugin.Misc.EmployeeManagement.Models;
using Nop.Plugin.Misc.EmployeeManagement.Services;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Misc.EmployeeManagement.Factories;
public class EmployeeModelFactory : IEmployeeModelFactory
{
    private readonly IEmployeeService _employeeService;

    public EmployeeModelFactory(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    public async Task<EmployeeListModel> PrepareEmployeeListModelAsync(EmployeeSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(searchModel);

        var employees = await _employeeService.GetAll(searchModel);
        var model = await new EmployeeListModel().PrepareToGridAsync(searchModel,
            employees, () =>
            {
                return employees.SelectAwait(async employee =>
                {
                    //var  = new EmployeeModel
                    //{
                    //    Id = employee.Id,
                    //  employee.Name,
                    //    Email =  Name =  employee.Email,
                    //    Phone = employee.Phone, 
                    //    JoinedDate = employee.JoinedDate,
                    //    DateOfBirth = employee.DateOfBirth,
                    //    EmployeeRoleName = employee.EmployeeRole.ToString(),
                    //    LeaveDate = employee.LeaveDate,
                    //    CurrentlyWorking = !employee.LeaveDate.HasValue
                    //};

                    var employeeModel = employee.ToModel<EmployeeModel>();
                    //employeeModel.CurrentlyWorking = employee.CurrentlyWorking;
                    return employeeModel;
                });
            }
            );
        return model;
    }

    public Task<EmployeeModel> PrepareEmployeeModelAsync(EmployeeModel model, EmployeeDomain employee)
    {
        if (employee != null)
        {
            if(model == null)
            {
                model = employee.ToModel<EmployeeModel>();
                //model.EmployeeRoleName = employee.EmployeeRole.ToString();
            }
        }
        if (employee == null)
        {
            model = new EmployeeModel();
        }
        return Task.FromResult(model);
    }

    public Task<EmployeeSearchModel> PrepareEmployeeSearchModelAsync(EmployeeSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(searchModel);
        searchModel.SetGridPageSize();

        return Task.FromResult(searchModel);
    }
}
