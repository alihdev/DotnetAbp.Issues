using DotnetAbp.Issues.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DotnetAbp.Issues.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class IssuesController : AbpControllerBase
{
    protected IssuesController()
    {
        LocalizationResource = typeof(IssuesResource);
    }
}
