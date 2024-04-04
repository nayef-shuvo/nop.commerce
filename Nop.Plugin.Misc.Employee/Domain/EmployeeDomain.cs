using System;
using Nop.Core;
using Nop.Core.Domain.Seo;
using Nop.Plugin.Misc.EmployeeManagement.Utils;

namespace Nop.Plugin.Misc.EmployeeManagement.Domain;
public class EmployeeDomain : BaseEntity, ISlugSupported
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime JoinedDate { get; set; }
    public DateTime? LeaveDate { get; set; }
    public EmployeeRole EmployeeRole { get; set; }

    public bool CurrentlyWorking => !LeaveDate.HasValue;

    public (int, int, int) EmployeeTenure
    {
        get
        {
            var endDate = LeaveDate ?? DateTime.Now;
            return TimeCalculator(endDate, JoinedDate);
        }
    }

    public (int, int, int) Age => TimeCalculator(DateTime.Now, DateOfBirth);



    private static (int years, int months, int days) TimeCalculator(DateTime endDate, DateTime startDate)
    {
        var years = endDate.Year - startDate.Year;
        var months = endDate.Month - startDate.Month;
        var days = endDate.Day - startDate.Day;

        // Adjust for negative months or days
        if (months < 0 || (months == 0 && days < 0))
        {
            years--;
            months += (months < 0) ? 12 : 0;
        }
        if (days < 0)
        {
            var daysInLastMonth = DateTime.DaysInMonth(endDate.Year, endDate.Month - 1);
            days += daysInLastMonth;
            months--;
        }
        return (years, months, days);
    }

}
