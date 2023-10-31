using DotnetAbp.Issues.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace DotnetAbp.Issues.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(IssuesEntityFrameworkCoreModule),
    typeof(IssuesApplicationContractsModule)
    )]
public class IssuesDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
