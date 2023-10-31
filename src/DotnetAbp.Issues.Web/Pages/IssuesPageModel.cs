using DotnetAbp.Issues.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DotnetAbp.Issues.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class IssuesPageModel : AbpPageModel
{
    protected IssuesPageModel()
    {
        LocalizationResourceType = typeof(IssuesResource);
    }
}
