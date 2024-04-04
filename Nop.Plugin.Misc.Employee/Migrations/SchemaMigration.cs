using FluentMigrator;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.EmployeeManagement.Domain;

namespace Nop.Plugin.Misc.EmployeeManagement.Migrations;

[NopMigration("2024/03/21 08:16:55", "Inital migration. Table create.", MigrationProcessType.NoMatter)]
public class SchemaMigration : AutoReversingMigration
{
    public override void Up()
    {   
        Create.TableFor<EmployeeDomain>();
    }
}
