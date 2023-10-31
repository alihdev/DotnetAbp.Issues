using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DotnetAbp.Issues.Data;
using Volo.Abp.DependencyInjection;

namespace DotnetAbp.Issues.EntityFrameworkCore;

public class EntityFrameworkCoreIssuesDbSchemaMigrator
    : IIssuesDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreIssuesDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the IssuesDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<IssuesDbContext>()
            .Database
            .MigrateAsync();
    }
}
