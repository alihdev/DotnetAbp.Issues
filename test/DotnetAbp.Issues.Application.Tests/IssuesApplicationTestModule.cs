using Volo.Abp.Modularity;

namespace DotnetAbp.Issues;

[DependsOn(
    typeof(IssuesApplicationModule),
    typeof(IssuesDomainTestModule)
    )]
public class IssuesApplicationTestModule : AbpModule
{

}
