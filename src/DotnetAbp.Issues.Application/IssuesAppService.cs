using System;
using System.Collections.Generic;
using System.Text;
using DotnetAbp.Issues.Localization;
using Volo.Abp.Application.Services;

namespace DotnetAbp.Issues;

/* Inherit your application services from this class.
 */
public abstract class IssuesAppService : ApplicationService
{
    protected IssuesAppService()
    {
        LocalizationResource = typeof(IssuesResource);
    }
}
