using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DotnetAbp.Issues.Data;

/* This is used if database provider does't define
 * IIssuesDbSchemaMigrator implementation.
 */
public class NullIssuesDbSchemaMigrator : IIssuesDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
