using DotnetAbp.Issues.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace DotnetAbp.Issues;

[DependsOn(
    typeof(IssuesEntityFrameworkCoreTestModule)
    )]
public class IssuesDomainTestModule : AbpModule
{

}
