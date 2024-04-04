using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.EmployeeManagement.Domain;


namespace Nop.Plugin.Misc.EmployeeManagement;

public class EmployeeMappingBuilder : NopEntityBuilder<EmployeeDomain>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(EmployeeDomain.Id)).AsInt32().PrimaryKey().Identity()
            .WithColumn(nameof(EmployeeDomain.Name)).AsString(50).NotNullable()
            .WithColumn(nameof(EmployeeDomain.Email)).AsString(50).Unique().NotNullable()
            .WithColumn(nameof(EmployeeDomain.Phone)).AsString(20).NotNullable()
            .WithColumn(nameof(EmployeeDomain.DateOfBirth)).AsDateTime().NotNullable()
            .WithColumn(nameof(EmployeeDomain.JoinedDate)).AsDateTime().NotNullable()
            .WithColumn(nameof(EmployeeDomain.LeaveDate)).AsDateTime().Nullable()
            .WithColumn(nameof(EmployeeDomain.EmployeeRole)).AsInt32().NotNullable();
    }
}
