using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace DotnetAbp.Issues;

public class IssuesWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<IssuesWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
